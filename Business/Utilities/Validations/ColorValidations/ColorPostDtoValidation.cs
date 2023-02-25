namespace Business.Utilities.Validations.ColorValidations;
public class ColorPostDtoValidation : AbstractValidator<ColorPostDto>
{
    public ColorPostDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Adı boş ola bilməz.")
            .NotNull().WithMessage("Adı boş ola bilməz.")
            .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
    }
}