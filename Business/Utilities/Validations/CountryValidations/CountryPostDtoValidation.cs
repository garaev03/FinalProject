namespace Business.Utilities.Validations.CountryValidations;
public class CountryPostDtoValidation:AbstractValidator<CountryPostDto>
{
    public CountryPostDtoValidation()
    {
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Adı boş ola bilməz.")
          .NotNull().WithMessage("Adı boş ola bilməz.")
          .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
    }
}