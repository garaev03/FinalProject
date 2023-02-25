namespace Business.Utilities.Validations.AppUserValidations;
public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz.")
            .NotNull().WithMessage("Email boş ola bilməz.")
            .EmailAddress().WithMessage("Email düzgün deyil.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol boş ola bilməz.")
            .NotNull().WithMessage("Parol boş ola bilməz.")
            .MinimumLength(5).WithMessage("Parol minimum 5 simvoldan ibarət olmalıdır.");
    }
}