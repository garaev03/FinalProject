namespace Business.Utilities.Validations.SettingValidations
{
    public class SettingUpdateDtoValidation : AbstractValidator<SettingUpdateDto>
    {
        private readonly NumberValidation _numberValidation = new();
        private readonly EmailValidation _emailValidation = new();
        public SettingUpdateDtoValidation()
        {
            RuleFor(s => s.FooterRight)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .NotNull().WithMessage("Boş ola bilməz.");
            RuleFor(s => s.FooterLeft)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .NotNull().WithMessage("Boş ola bilməz.");
            RuleFor(s => s.TelephoneNumber)
                .NotEmpty().WithMessage("Nömrə boş ola bilməz.")
                .NotNull().WithMessage("Nömrə boş ola bilməz.")
                .Must(_numberValidation.IsNumber).WithMessage("Nömrə düzgün deyil.")
                .Must(_numberValidation.IsAzerbaijanNumber).WithMessage("Operator kodu yanlışdır.");
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz.")
                .NotNull().WithMessage("Email boş ola bilməz.")
                .EmailAddress().WithMessage("Email düzgün deyil.")
                .Must(_emailValidation.isEmail).WithMessage("Email düzgün deyil.");
        }
    }
}