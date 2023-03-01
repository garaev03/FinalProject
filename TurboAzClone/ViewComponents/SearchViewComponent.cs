namespace TurboAzClone.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly AllServices _allServices;
        public SearchViewComponent(AllServices allServices)
        {
            _allServices = allServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(SearchIdsVM svm)
        {
            await GetAllModels();
            return View(svm);
        }

        private async Task GetAllModels()
        {
            ViewBag.Makes = await _allServices._makeService.GetAllAsync();
            ViewBag.Models = await _allServices._modelService.GetAllAsync();
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
    }
}