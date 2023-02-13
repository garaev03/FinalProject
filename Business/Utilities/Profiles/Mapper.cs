using AutoMapper;
using Entities.Concrets;
using Entities.DTOs.BanDtos;
using Entities.DTOs.CityDtos;
using Entities.DTOs.ColorDtos;
using Entities.DTOs.CountryDtos;
using Entities.DTOs.CurrencyDtos;
using Entities.DTOs.DriveTrainDtos;
using Entities.DTOs.EngineCapacityDtos;
using Entities.DTOs.FuelDtos;
using Entities.DTOs.GearBoxDtos;
using Entities.DTOs.MakeDtos;
using Entities.DTOs.MileageTypeDtos;
using Entities.DTOs.ModelDtos;
using Entities.DTOs.OwnerCountDtos;
using Entities.DTOs.SeatDtos;
using Entities.DTOs.StatusDtos;
using Entities.DTOs.VehicleConditionDtos;
using Entities.DTOs.VehicleDtos;
using Entities.DTOs.VehicleReportDtos;
using Entities.DTOs.VehicleSupplyDtos;
using Entities.DTOs.YearDtos;

namespace Business.Utilities.Profiles
{
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

            CreateMap<Status, StatusGetDto>();
            CreateMap<StatusPostDto, Status>();

            CreateMap<VehicleCondition, VehicleConditionGetDto>();
            CreateMap<VehicleConditionPostDto, VehicleCondition>();

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
}
