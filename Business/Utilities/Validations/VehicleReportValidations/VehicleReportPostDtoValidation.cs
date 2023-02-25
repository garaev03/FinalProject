namespace Business.Utilities.Validations.VehicleReportValidations;
public class VehicleReportPostDtoValidation:AbstractValidator<VehicleReportPostDto>
{
    public VehicleReportPostDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Adı boş ola bilməz.")
            .NotNull().WithMessage("Adı boş ola bilməz.")
            .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Məlumat boş ola bilməz.")
            .NotNull().WithMessage("Məlumat boş ola bilməz.")
            .MinimumLength(2).WithMessage("Məlumat ən azı 2 simvol olmalıdır.");
    }
}