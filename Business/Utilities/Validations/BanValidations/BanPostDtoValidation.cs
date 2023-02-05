using Entities.DTOs.BanDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Validations.BanValidations
{
    public class BanPostDtoValidation:AbstractValidator<BanPostDto>
    {
        public BanPostDtoValidation()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Adı boş ola bilməz.")
              .NotNull().WithMessage("Adı boş ola bilməz.")
              .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        }
    }
}
