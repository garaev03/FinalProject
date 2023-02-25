namespace Business.Utilities.Validations.VehicleSupplyValidations;
public class VehicleSupplyPostDtoValidation:AbstractValidator<VehicleSupplyPostDto>
{
    public VehicleSupplyPostDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Adı boş ola bilməz.")
            .NotNull().WithMessage("Adı boş ola bilməz.")
            .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
    }
}