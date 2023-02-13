using Entities.DTOs.SeatDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Validations.SeatValidations
{
    public class SeatPostDtoValidation:AbstractValidator<SeatPostDto>
    {
        public SeatPostDtoValidation()
        {
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Sayı boş ola bilməz.")
                .NotNull().WithMessage("Sayı boş ola bilməz.")
                .GreaterThan(0).WithMessage("Sayı 0 və 0-dan kiçik ola bilməz.");
        }
    }
}
