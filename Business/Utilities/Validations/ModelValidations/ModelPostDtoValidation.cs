namespace Business.Utilities.Validations.ModelValidations;
public class ModelPostDtoValidation:AbstractValidator<ModelPostDto>
{
    public ModelPostDtoValidation()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Adı boş ola bilməz.")
         .NotNull().WithMessage("Adı boş ola bilməz.")
         .MinimumLength(2).WithMessage("Adı ən azı 2 simvol olmalıdır.");
        RuleFor(x => x.MakeId)
         .NotEmpty().WithMessage("Marka boş ola bilməz.")
         .NotNull().WithMessage("Marka boş ola bilməz.")
         .GreaterThan(-1).WithMessage("Marka daxil edin");
    }
}