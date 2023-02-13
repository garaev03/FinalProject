using Entities.DTOs.MakeDtos;
using FluentValidation;


namespace Business.Utilities.Validations.MakeValidations
{
    public class MakePostDtoValidation:AbstractValidator<MakePostDto>
    {
        public MakePostDtoValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Adı boş ola bilməz.")
               .NotNull().WithMessage("Adı boş ola bilməz.")
               .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        }
    }
}
