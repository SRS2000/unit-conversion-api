using Microsoft.Extensions.DependencyInjection;
using UnitConversion.Application.Interfaces;
using UnitConversion.Infrastructure.Services;

namespace UnitConversion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IConversionService, ConversionService>();

        return services;
    }
}