using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UnitConversion.Application.Validators;

namespace UnitConversion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ConversionRequestValidator>();

        return services;
    }
}