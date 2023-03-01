namespace TurboAzClone.Controllers
{
    public class VehicleController : Controller
    {
        private readonly AllServices _allServices;
        private readonly IVehicleService _vehicleService;
        private readonly VehiclePostDtoValidation _postValidator;
        private readonly VehicleUpdateDtoValidation _updateValidator;
        public VehicleController(AllServices allServices, VehiclePostDtoValidation validator, IVehicleService vehicleService, VehicleUpdateDtoValidation updateValidator)
        {
            _allServices = allServices;
            _postValidator = validator;
            _vehicleService = vehicleService;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> Autos(int makeId, int modelId, int banId, int cityId, int minPrice, int maxPrice, int currencyId, int fuelId, int yearId, int driveTrainId, int gearboxId, int milageMin, int milageMax, int ownerId, int seatId, int countryId)
        {
            List<VehicleGetDto> vehicles = await _vehicleService.GetAllAsync(x => !x.isDeleted && x.isConfirmed, true);
            IEnumerable<VehicleGetDto> enumvehicles = vehicles.Reverse<VehicleGetDto>();
            if (makeId != 0) enumvehicles = enumvehicles.Where(x => x.Model.MakeId == makeId);
            if (modelId != 0) enumvehicles = enumvehicles.Where(x => x.ModelId == modelId);
            if (banId != 0) enumvehicles = enumvehicles.Where(x => x.BanId == banId);
            if (cityId != 0) enumvehicles = enumvehicles.Where(x => x.CityId == cityId);
            if (minPrice != 0) enumvehicles = enumvehicles.Where(x => x.Price >= minPrice && x.CurrencyId == currencyId);
            if (maxPrice != 0) enumvehicles = enumvehicles.Where(x => x.Price <= maxPrice && x.CurrencyId == currencyId);
            if (fuelId != 0) enumvehicles = enumvehicles.Where(x => x.FuelId == fuelId);
            if (yearId != 0) enumvehicles = enumvehicles.Where(x => x.YearId == yearId);
            if (driveTrainId != 0) enumvehicles = enumvehicles.Where(x => x.DriveTrainId == driveTrainId);
            if (gearboxId != 0) enumvehicles = enumvehicles.Where(x => x.GearBoxId == gearboxId);
            if (milageMin != 0) enumvehicles = enumvehicles.Where(x => x.Milage >= milageMin);
            if (milageMax != 0) enumvehicles = enumvehicles.Where(x => x.Milage <= milageMax);
            if (ownerId != 0) enumvehicles = enumvehicles.Where(x => x.OwnerId == ownerId);
            if (seatId != 0) enumvehicles = enumvehicles.Where(x => x.SeatId == seatId);
            if (countryId != 0) enumvehicles = enumvehicles.Where(x => x.CountryId == countryId);

            vehicles = enumvehicles.ToList();
            AutoSearchVM asvm = new() { vehicles = vehicles, searchIds = new() { makeId = makeId, modelId = modelId, banId = banId, cityId = cityId, minPrice = minPrice, maxPrice = maxPrice, currencyId = currencyId, fuelId = fuelId, yearId = yearId, driveTrainId = driveTrainId, gearboxId = gearboxId, milageMin = milageMin, milageMax = milageMax, ownerId = ownerId, seatId = seatId, countryId = countryId } };
            return View(asvm);
        }
        public async Task<IActionResult> New()
        {
            await GetAllModels();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(VehiclePostDto postDto)
        {
            await GetAllModels();
            if (!_postValidator.ValidateAsync(postDto).Result.IsValid) return View();
            try
            {
                string PinCode = await _vehicleService.CreateAsync(postDto);
                MailMessage mail = new();
                mail.From = new MailAddress("turbo.az.clone.bot@gmail.com", "Turbo.Az Clone-Bot");
                mail.To.Add(new MailAddress(postDto.Email));
                mail.Subject = "PİNKOD";
                mail.Body = $"PINKOD  \n\nPinKodunuzu yadda saxlayın. Əks halda elanınıza düzəliş və ya silə bilməyəcəksiniz. \n\nPINKODUNUZ: {PinCode}";
                SmtpClient smtp = new();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("turbo.az.clone.bot@gmail.com", "ojcttgxspuahniqu");

                smtp.Send(mail);
            }
            catch (NotFoundException ex) { ModelState.AddModelError("", ex.Message); return View(); }
            catch (ImageException ex) { ModelState.AddModelError("formFiles", ex.Message); return View(); }
            catch (LimitExceededException ex) { ModelState.AddModelError("", ex.Message); return View(); }
            return RedirectToAction("index", "Home");
        }
        public async Task<IActionResult> Details(int id)
        {
            VehicleGetDto vehicle = new();
            try { vehicle = await _vehicleService.GetByIdAsync(id = id, true); await GetSimilarModels(vehicle.Id, vehicle.ModelId); }
            catch (NotFoundException ex) { ModelState.AddModelError("", ex.Message); return RedirectToAction("notfound", "error"); }
            return View(vehicle);
        }
        public async Task<IActionResult> Edit(int id, string PINCode)
        {
            await GetAllModels();
            VehicleUpdateDto updateDto = new();
            try
            {
                await _vehicleService.ValidatePIN(id, PINCode);
                updateDto.getDto = await _vehicleService.GetByIdAsync(id, true);
            }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            catch (WrongPINCodeException) { return Json(403); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VehicleUpdateDto updateDto)
        {
            try
            {
                await GetAllModels();
                updateDto.getDto = await _vehicleService.GetByIdAsync(updateDto.getDto.Id, true);
                if (!_updateValidator.ValidateAsync(updateDto).Result.IsValid)
                {
                    var error = _updateValidator.ValidateAsync(updateDto).Result.Errors.FirstOrDefault();
                    ModelState.AddModelError("", error.ErrorMessage);
                    return View(updateDto);
                }
                await _vehicleService.UpdateAsync(updateDto);
            }
            catch (NotFoundException ex) { ModelState.AddModelError("", ex.Message); return View(); }
            catch (ImageException ex) { ModelState.AddModelError("formFiles", ex.Message); return View(); }
            return RedirectToAction("details", new { id = updateDto.getDto.Id });
        }
        public async Task<IActionResult> Delete(int id, string PINCode)
        {
            try
            {
                await _vehicleService.ValidatePIN(id, PINCode);
                await _vehicleService.DeleteAsync(id);
            }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            catch (WrongPINCodeException) { return Json(403); }
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> GetModels(int makeId)
        {
            if (makeId == 0) return Json(null);
            return Json(await _allServices._modelService.GetAllAsync(x => !x.isDeleted && x.MakeId == makeId));
        }
        [NonAction]
        private async Task GetAllModels()
        {
            ViewBag.Models = await _allServices._modelService.GetAllAsync();
            ViewBag.Makes = await _allServices._makeService.GetAllAsync();
            ViewBag.Bans = await _allServices._banService.GetAllAsync();
            ViewBag.Owners = await _allServices._ownerCountService.GetAllAsync();
            ViewBag.Fuels = await _allServices._fuelService.GetAllAsync();
            ViewBag.DriveTrains = await _allServices._driveTrainService.GetAllAsync();
            ViewBag.GearBoxes = await _allServices._gearBoxService.GetAllAsync();
            ViewBag.MileageTypes = await _allServices._mileageTypeService.GetAllAsync();
            ViewBag.Years = await _allServices._yearService.GetAllAsync();
            ViewBag.Colors = await _allServices._colorService.GetAllAsync();
            ViewBag.EngineCapacities = await _allServices._engineCapacityService.GetAllAsync();
            ViewBag.Seats = await _allServices._seatService.GetAllAsync();
            ViewBag.Supplies = await _allServices._supplyService.GetAllAsync();
            ViewBag.Reports = await _allServices._reportService.GetAllAsync();
            ViewBag.Currencies = await _allServices._currencyService.GetAllAsync();
            ViewBag.Countries = await _allServices._countryService.GetAllAsync();
            ViewBag.Cities = await _allServices._cityService.GetAllAsync();
        }
        [NonAction]
        private async Task GetSimilarModels(int vehicleId, int modelId)
        {
            ViewData["Vehicles"] = await _vehicleService.GetAllAsync(x => !x.isDeleted && x.ModelId == modelId && x.isConfirmed && x.Id != vehicleId, true);
        }
    }
}