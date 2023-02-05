using AutoMapper;
using Entities.Concrets;
using Entities.DTOs.BanDtos;
using Entities.DTOs.ColorDtos;
using Entities.DTOs.CountryDtos;
using Entities.DTOs.CurrencyDtos;
using Entities.DTOs.DriveTrainDtos;
using Entities.DTOs.EngineCapacityDtos;

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
        }
    }
}
