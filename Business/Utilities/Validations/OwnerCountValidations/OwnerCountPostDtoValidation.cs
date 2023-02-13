using Entities.DTOs.OwnerCountDtos;
using FluentValidation;

namespace Business.Utilities.Validations.OwnerCountValidations
{
    public class OwnerCountPostDtoValidation:AbstractValidator<OwnerCountPostDto>
    {
        public OwnerCountPostDtoValidation()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Adı boş ola bilməz.")
                    .NotNull().WithMessage("Adı boş ola bilməz.")
                    .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        }
    }
}
