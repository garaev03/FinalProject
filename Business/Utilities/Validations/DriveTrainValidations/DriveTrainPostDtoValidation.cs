using Entities.DTOs.DriveTrainDtos;
using FluentValidation;

namespace Business.Utilities.Validations.DriveTrainValidations
{
    public class DriveTrainPostDtoValidation:AbstractValidator<DriveTrainPostDto>
    {
        public DriveTrainPostDtoValidation()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Adı boş ola bilməz.")
           .NotNull().WithMessage("Adı boş ola bilməz.")
           .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        }
    }
}
