using Entities.DTOs.StatusDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Validations.StatusValidations
{
    public class StatusPostDtoValidation:AbstractValidator<StatusPostDto>
    {
        public StatusPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Adı boş ola bilməz.")
                .NotNull().WithMessage("Adı boş ola bilməz.")
                .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        }
    }
}
