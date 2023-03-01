namespace Business.Utilities.Validations.AppUserValidations;
public class RegisterValidator : AbstractValidator<RegisterDto>
{
    private readonly NumberValidation _numberValidation = new();
    private readonly EmailValidation _emailValidation = new();
    public RegisterValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Ad boş ola bilməz.")
           .NotNull().WithMessage("Ad boş ola bilməz.")
           .MinimumLength(3).WithMessage("Ad minimum 3 hərfdən ibarət olmalıdır.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz.")
            .NotNull().WithMessage("Email boş ola bilməz.")
            .EmailAddress().WithMessage("Email düzgün deyil.")
            .Must(_emailValidation.isEmail).WithMessage("Email düzgün deyil.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Nömrə boş ola bilməz.")
            .NotNull().WithMessage("Nömrə boş ola bilməz.")
            .Must(_numberValidation.IsNumber).WithMessage("Nömrə düzgün deyil.")
            .Must(_numberValidation.IsAzerbaijanNumber).WithMessage("Operator kodu yanlışdır");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol boş ola bilməz.")
            .NotNull().WithMessage("Parol boş ola bilməz.")
            .MinimumLength(5).WithMessage("Parol minimum 5 simvoldan ibarət olmalıdır.");
    }
}