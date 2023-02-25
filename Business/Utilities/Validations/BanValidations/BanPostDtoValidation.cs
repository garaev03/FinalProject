namespace Business.Utilities.Validations.BanValidations;
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