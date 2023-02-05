using Entities.DTOs.CurrencyDtos;
using FluentValidation;

namespace Business.Utilities.Validations.CurrencyValidations
{
    public class CurrencyPostDtoValidation:AbstractValidator<CurrencyPostDto>
    {
        public CurrencyPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Adı boş ola bilməz.")
                .NotNull().WithMessage("Adı boş ola bilməz.")
                .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        }
    }
}
