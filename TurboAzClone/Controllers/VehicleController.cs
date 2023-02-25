using Business.Services.Implementations;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Business.Utilities.Validations.VehicleValidations;
using Entities.DTOs.VehicleDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Controllers
{
    public class VehicleController : Controller
    {
        private readonly AllServices _allServices;
        private readonly IVehicleService _vehicleService;
        private readonly VehiclePostDtoValidation _validator;
        public VehicleController(AllServices allServices, VehiclePostDtoValidation validator, IVehicleService vehicleService)
        {
            _allServices = allServices;
            _validator = validator;
            _vehicleService = vehicleService;
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
            if (!_validator.ValidateAsync(postDto).Result.IsValid) return View();
            try { await _vehicleService.CreateAsync(postDto); }
            catch (NotFoundException ex) { ModelState.AddModelError("", ex.Message); return View(); }
            catch (ImageException ex) { ModelState.AddModelError("formFiles", ex.Message); return View(); }
            catch (LimitExceededException ex) { ModelState.AddModelError("", ex.Message); return View(); }
            return RedirectToAction("index", "Home");
        }
        public async Task<IActionResult> Details(int id)
        {
            VehicleGetDto vehicle = new();
            try { vehicle = await _vehicleService.GetByIdAsync(id, true); await GetSimilarModels(vehicle.Id, vehicle.ModelId); }
            catch (NotFoundException ex) { ModelState.AddModelError("", ex.Message); return RedirectToAction("notfound", "error"); }
            return View(vehicle);
        }
        public async Task<IActionResult> Edit(int id, string PINCode)
        {
            VehicleUpdateDto updateDto = new();
            try
            {
                await _vehicleService.ValidatePIN(id, PINCode);
                updateDto.getDto = await _vehicleService.GetByIdAsync(id, true);
            }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            catch (WrongPINCodeException ex) { return Json(new { Code = 404, ex.Message }); }
            return View(updateDto);
        }
        public async Task<IActionResult> GetModels(int makeId)
        {
            if (makeId == 0)
                return Json(null);
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
