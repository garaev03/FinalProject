using Entities.DTOs.CityDtos;
using FluentValidation;

namespace Business.Utilities.Validations.CityValidations
{
    public class CityPostDtoValidation:AbstractValidator<CityPostDto>
    {
        public CityPostDtoValidation()
        {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("Adı boş ola bilməz.")
                   .NotNull().WithMessage("Adı boş ola bilməz.")
                   .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
            RuleFor(x => x.Code)
                  .NotEmpty().WithMessage("Kod boş ola bilməz.")
                  .NotNull().WithMessage("Kod boş ola bilməz.")
                  .GreaterThan(0).WithMessage("Kod 0 və 0-dan kiçik ola bilməz.");
        }
    }
}
