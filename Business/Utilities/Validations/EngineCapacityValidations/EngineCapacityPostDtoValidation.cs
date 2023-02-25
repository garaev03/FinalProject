namespace Business.Utilities.Validations.EngineCapacityValidations;
public class EngineCapacityPostDtoValidation : AbstractValidator<EngineCapacityPostDto>
{
    public EngineCapacityPostDtoValidation()
    {
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Həcmi boş ola bilməz.")
            .NotNull().WithMessage("Həcmi boş ola bilməz.")
            .GreaterThan(9).WithMessage("Həcmi 10-dan kiçik ola bilməz.");
    }
}