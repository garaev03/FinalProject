namespace Business.Utilities.Validations.GearBoxValidations;
public class GearBoxPostDtoValidation:AbstractValidator<GearBoxPostDto>
{
    public GearBoxPostDtoValidation()
    {
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Adı boş ola bilməz.")
          .NotNull().WithMessage("Adı boş ola bilməz.")
          .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
    }
}