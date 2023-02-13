using Entities.DTOs.YearDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Validations.YearValidations
{
    public class YearPostDtoValidation:AbstractValidator<YearPostDto>
    {
        public YearPostDtoValidation()
        {
             RuleFor(x => x.Value)
                .NotEmpty().WithMessage("İli boş ola bilməz.")
                .NotNull().WithMessage("İli boş ola bilməz.")
                .GreaterThan(1885).WithMessage("İli 1886-dan kiçik ola bilməz.");
        }
    }
}
