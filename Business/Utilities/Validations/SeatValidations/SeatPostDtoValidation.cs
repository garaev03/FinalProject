namespace Business.Utilities.Validations.SeatValidations;
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