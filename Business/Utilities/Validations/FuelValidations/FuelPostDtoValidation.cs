﻿namespace Business.Utilities.Validations.FuelValidations;
public class FuelPostDtoValidation:AbstractValidator<FuelPostDto>
{
    public FuelPostDtoValidation()
    {
        RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Adı boş ola bilməz.")
             .NotNull().WithMessage("Adı boş ola bilməz.")
             .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
    }
}