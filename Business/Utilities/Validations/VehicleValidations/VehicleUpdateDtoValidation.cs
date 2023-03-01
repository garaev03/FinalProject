namespace Business.Utilities.Validations.VehicleValidations;
public class VehicleUpdateDtoValidation : AbstractValidator<VehicleUpdateDto>
{
    public VehicleUpdateDtoValidation()
    {
        RuleFor(x => x.Description)
              .NotEmpty().WithMessage("Məlumat boş ola bilməz.")
              .NotNull().WithMessage("Məlumat boş ola bilməz.");
        RuleFor(x => x.EnginePower)
              .NotEmpty().WithMessage("Mühərrik gücü boş ola bilməz.")
              .NotNull().WithMessage("Mühərrik gücü boş ola bilməz.")
              .GreaterThan(0).WithMessage("Güc 0-dan böyük olmalıdır.");
        RuleFor(x => x.Milage)
              .NotEmpty().WithMessage("Yürüş boş ola bilməz.")
              .NotNull().WithMessage("Yürüş boş ola bilməz.")
              .GreaterThan(-1).WithMessage("Yürüş mənfi ədəd ola bilməz.");
        RuleFor(x => x.Price)
              .NotEmpty().WithMessage("Qiymət boş ola bilməz.")
              .NotNull().WithMessage("Qiymət boş ola bilməz.")
              .GreaterThan(499).WithMessage("Qiymət ən az 500 olmalıdır.");
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
        RuleFor(x => x.YearId)
               .NotEmpty().WithMessage("İl seçilməlidir.")
               .NotNull().WithMessage("İl seçilməlidir.")
               .GreaterThan(0).WithMessage("İl seçilməlidir.");
        RuleFor(x => x.GearBoxId)
               .NotEmpty().WithMessage("Sürət qutusu seçilməlidir.")
               .NotNull().WithMessage("Sürət qutusu seçilməlidir.")
               .GreaterThan(0).WithMessage("Sürət qutusu seçilməlidir.");
        RuleFor(x => x.MainImageId)
               .NotEmpty().WithMessage("Əsas şəkil seçilməlidir.")
               .NotNull().WithMessage("Əsas şəkil seçilməlidir.")
               .GreaterThan(0).WithMessage("Əsas şəkil seçilməlidir.");
        RuleFor(x => x.ImageIds)
               .NotEmpty().WithMessage("Şəkil boş ola bilməz.")
               .NotNull().WithMessage("Şəkil boş ola bilməz.")
               .Must(x => x.Count >= 3).WithMessage("Şəkillərin sayı 3-dən az ola bilməz.");
    }
}