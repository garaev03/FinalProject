namespace Business.Utilities.Profiles;
public class Mapper:Profile
{
    public Mapper()
    {
        CreateMap<Ban, BanGetDto>();
        CreateMap<BanPostDto, Ban>();

        CreateMap<Color, ColorGetDto>();
        CreateMap<ColorPostDto, Color>();

        CreateMap<Country, CountryGetDto>();
        CreateMap<CountryPostDto, Country>();

        CreateMap<Currency, CurrencyGetDto>();
        CreateMap<CurrencyPostDto, Currency>();

        CreateMap<DriveTrain, DriveTrainGetDto>();
        CreateMap<DriveTrainPostDto, DriveTrain>();

        CreateMap<EngineCapacity, EngineCapacityGetDto>();
        CreateMap<EngineCapacityPostDto, EngineCapacity>();

        CreateMap<MileageType, MileageTypeGetDto>();
        CreateMap<MileageTypePostDto, MileageType>();

        CreateMap<Fuel, FuelGetDto>();
        CreateMap<FuelPostDto, Fuel>();

        CreateMap<GearBox, GearBoxGetDto>();
        CreateMap<GearBoxPostDto, GearBox>();

        CreateMap<VehicleReport, VehicleReportGetDto>();
        CreateMap<VehicleReportPostDto, VehicleReport>();

        CreateMap<Make, MakeGetDto>();
        CreateMap<MakePostDto, Make>();

        CreateMap<Seat, SeatGetDto>();
        CreateMap<SeatPostDto, Seat>();

        CreateMap<OwnerCount, OwnerCountGetDto>();
        CreateMap<OwnerCountPostDto, OwnerCount>();

        CreateMap<VehicleSupply, VehicleSupplyGetDto>();
        CreateMap<VehicleSupplyPostDto, VehicleSupply>();

        CreateMap<Year, YearGetDto>();
        CreateMap<YearPostDto, Year>();

        CreateMap<Model, ModelGetDto>();
        CreateMap<ModelPostDto, Model>();

        CreateMap<City, CityGetDto>();
        CreateMap<CityPostDto, City>();

        CreateMap<Vehicle, VehicleGetDto>();
        CreateMap<VehiclePostDto, Vehicle>();
    }
}