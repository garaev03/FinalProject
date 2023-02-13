using Entities.Concrets;
using Entities.DTOs.VehicleDtos;
using FluentValidation;

namespace Business.Utilities.Validations.VehicleValidations
{
    public class VehiclePostDtoValidation : AbstractValidator<VehiclePostDto>
    {
        public VehiclePostDtoValidation()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email boş ola bilməz.")
                 .NotNull().WithMessage("Email boş ola bilməz.")
                 .EmailAddress().WithMessage("Email düzgün deyil.");
            RuleFor(x => x.Description)
                 .NotEmpty().WithMessage("Məlumat boş ola bilməz.")
                 .NotNull().WithMessage("Məlumat boş ola bilməz.");
            RuleFor(x => x.EnginePower)
                .NotEmpty().WithMessage("Mühərrik gücü boş ola bilməz.")
                .NotNull().WithMessage("Mühərrik gücü boş ola bilməz.")
                .GreaterThan(0).WithMessage("Güc 0-dan böyük olmalıdır.");
            RuleFor(x => x.OwnerName)
               .NotEmpty().WithMessage("Ad boş ola bilməz.")
               .NotNull().WithMessage("Ad boş ola bilməz.")
               .MinimumLength(1).WithMessage("Adın uzunluğu ən az 1 simvol olmalıdır.");
            RuleFor(x => x.Milage)
               .NotEmpty().WithMessage("Yürüş boş ola bilməz.")
               .NotNull().WithMessage("Yürüş boş ola bilməz.")
               .GreaterThan(-1).WithMessage("Yürüş mənfi ədəd ola bilməz.");
            RuleFor(x => x.Price)
              .NotEmpty().WithMessage("Qiymət boş ola bilməz.")
              .NotNull().WithMessage("Qiymət boş ola bilməz.")
              .GreaterThan(499).WithMessage("Qiymət ən az 500 olmalıdır.");
            RuleFor(x => x.PhoneNumber)
              .NotEmpty().WithMessage("Nömrə boş ola bilməz.")
              .NotNull().WithMessage("Nömrə boş ola bilməz.");
            RuleFor(x => x.BanId)
              .NotEmpty().WithMessage("Ban boş ola bilməz.")
              .NotNull().WithMessage("Ban boş ola bilməz.")
              .GreaterThan(0).WithMessage("Ban boş ola bilməz.");
            RuleFor(x => x.CityId)
              .NotEmpty().WithMessage("Şəhər boş ola bilməz.")
              .NotNull().WithMessage("Şəhər boş ola bilməz.")
              .GreaterThan(0).WithMessage("Şəhər boş ola bilməz.");
            RuleFor(x => x.ColorId)
              .NotEmpty().WithMessage("Rəng boş ola bilməz.")
              .NotNull().WithMessage("Rəng boş ola bilməz.")
              .GreaterThan(0).WithMessage("Rəng boş ola bilməz.");
            RuleFor(x => x.CountryId)
              .NotEmpty().WithMessage("Ölkə boş ola bilməz.")
              .NotNull().WithMessage("Ölkə boş ola bilməz.")
              .GreaterThan(0).WithMessage("Ölkə boş ola bilməz.");
            RuleFor(x => x.CurrencyId)
              .NotEmpty().WithMessage("Məzənnə boş ola bilməz.")
              .NotNull().WithMessage("Məzənnə boş ola bilməz.")
              .GreaterThan(0).WithMessage("Məzənnə boş ola bilməz.");
            RuleFor(x => x.DriveTrainId)
              .NotEmpty().WithMessage("Ötürücü boş ola bilməz.")
              .NotNull().WithMessage("Ötürücü boş ola bilməz.")
              .GreaterThan(0).WithMessage("Ötürücü boş ola bilməz.");
            RuleFor(x => x.EngineCapacityId)
              .NotEmpty().WithMessage("Mühərrik həcmi boş ola bilməz.")
              .NotNull().WithMessage("Mühərrik həcmi boş ola bilməz.")
              .GreaterThan(0).WithMessage("Mühərrik həcmi boş ola bilməz.");
            RuleFor(x => x.FuelId)
                    .NotEmpty().WithMessage("Yanacaq növü boş ola bilməz.")
                    .NotNull().WithMessage("Yanacaq növü boş ola bilməz.")
                    .GreaterThan(0).WithMessage("Yanacaq növü boş ola bilməz.");
            RuleFor(x => x.MileageTypeId)
                    .NotEmpty().WithMessage("Kilometraj seçilməlidir.")
                    .NotNull().WithMessage("Kilometraj seçilməlidir.")
                    .GreaterThan(0).WithMessage("Kilometraj seçilməlidir.");
            RuleFor(x => x.SeatId)
                    .NotEmpty().WithMessage("Oturacaq seçilməlidir.")
                    .NotNull().WithMessage("Oturacaq seçilməlidir.")
                    .GreaterThan(0).WithMessage("Oturacaq seçilməlidir.");
            RuleFor(x => x.ModelId)
                    .NotEmpty().WithMessage("Model seçilməlidir.")
                    .NotNull().WithMessage("Model seçilməlidir.")
                    .GreaterThan(0).WithMessage("Model seçilməlidir.");
            RuleFor(x => x.YearId)
                    .NotEmpty().WithMessage("İl seçilməlidir.")
                    .NotNull().WithMessage("İl seçilməlidir.")
                    .GreaterThan(0).WithMessage("İl seçilməlidir.");
            RuleFor(x => x.GearBoxId)
                    .NotEmpty().WithMessage("Sürət qutusu seçilməlidir.")
                    .NotNull().WithMessage("Sürət qutusu seçilməlidir.")
                    .GreaterThan(0).WithMessage("Sürət qutusu seçilməlidir.");
            RuleFor(x => x.OwnerId)
                 .NotEmpty().WithMessage("Sahib seçilməlidir.")
                 .NotNull().WithMessage("Sahib seçilməlidir.")
                 .GreaterThan(0).WithMessage("Sahib seçilməlidir.");
            RuleFor(x => x.VIN)
                   .NotEmpty().WithMessage("Vin Kod boş ola bilməz.")
                   .NotNull().WithMessage("Vin Kod boş ola bilməz.");
        }
    }
}
