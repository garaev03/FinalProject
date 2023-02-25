namespace Business.Services.Implementations;
public class AllServices
{
    public readonly IMakeService _makeService;
    public readonly IBanService _banService;
    public readonly ICityService _cityService;
    public readonly IColorService _colorService;
    public readonly ICountryService _countryService;
    public readonly ICurrencyService _currencyService;
    public readonly IDriveTrainService _driveTrainService;
    public readonly IEngineCapacityService _engineCapacityService;
    public readonly IFuelService _fuelService;
    public readonly IGearBoxService _gearBoxService;
    public readonly IMileageTypeService _mileageTypeService;
    public readonly IModelService _modelService;
    public readonly IOwnerCountService _ownerCountService;
    public readonly IVehicleReportService _reportService;
    public readonly ISeatService _seatService;
    public readonly IVehicleSupplyService _supplyService;
    public readonly IYearService _yearService;

    public AllServices(
        IBanService banService,
        ICityService cityService,
        IColorService colorService,
        ICountryService countryService,
        ICurrencyService currencyService,
        IDriveTrainService driveTrainService,
        IEngineCapacityService engineCapacityService,
        IFuelService fuelService,
        IGearBoxService gearBoxService,
        IMileageTypeService mileageTypeService,
        IModelService modelService,
        IOwnerCountService ownerCountService,
        IVehicleReportService reportService,
        ISeatService seatService,
        IVehicleSupplyService supplyService,
        IYearService yearService,
        IMakeService makeService)
    {
        _banService = banService;
        _cityService = cityService;
        _colorService = colorService;
        _countryService = countryService;
        _currencyService = currencyService;
        _driveTrainService = driveTrainService;
        _engineCapacityService = engineCapacityService;
        _fuelService = fuelService;
        _gearBoxService = gearBoxService;
        _mileageTypeService = mileageTypeService;
        _modelService = modelService;
        _ownerCountService = ownerCountService;
        _reportService = reportService;
        _seatService = seatService;
        _supplyService = supplyService;
        _yearService = yearService;
        _makeService = makeService;
    }
}
