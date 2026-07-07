using FluentValidation;
using UnitConversion.Application.DTOs;

namespace UnitConversion.Application.Validators;

public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
{
    public ConversionRequestValidator()
    {
        RuleFor(x => x.Value)
            .NotNull();

        RuleFor(x => x.FromUnit)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.ToUnit)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.Category)
            .IsInEnum();

        RuleFor(x => x)
            .Must(x => !string.Equals(x.FromUnit, x.ToUnit, StringComparison.OrdinalIgnoreCase))
            .WithMessage("Source and destination units cannot be the same.");
    }
}