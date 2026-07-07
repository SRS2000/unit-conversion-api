using UnitConversion.Application.DTOs;
using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Enums;

namespace UnitConversion.Infrastructure.Services;

public class ConversionService : IConversionService
{
    // Factors relative to the base unit (Meter)
    private readonly Dictionary<string, double> _lengthUnits =
        new(StringComparer.OrdinalIgnoreCase)
        {
            { "Millimeter", 0.001 },
            { "Centimeter", 0.01 },
            { "Meter", 1 },
            { "Kilometer", 1000 },
            { "Inch", 0.0254 },
            { "Foot", 0.3048 },
            { "Yard", 0.9144 },
            { "Mile", 1609.344 }
        };

    // Factors relative to the base unit (Kilogram)
    private readonly Dictionary<string, double> _weightUnits =
        new(StringComparer.OrdinalIgnoreCase)
        {
            { "Milligram", 0.000001 },
            { "Gram", 0.001 },
            { "Kilogram", 1 },
            { "Ton", 1000 },
            { "Ounce", 0.0283495 },
            { "Pound", 0.45359237 }
        };

    public Task<ConversionResponse> ConvertAsync(ConversionRequest request)
    {
        double result = request.Category switch
        {
            ConversionCategory.Length =>
                ConvertUsingFactor(request.Value, request.FromUnit, request.ToUnit, _lengthUnits),

            ConversionCategory.Weight =>
                ConvertUsingFactor(request.Value, request.FromUnit, request.ToUnit, _weightUnits),

            ConversionCategory.Temperature =>
                ConvertTemperature(request.Value, request.FromUnit, request.ToUnit),

            _ => throw new ArgumentException("Unsupported conversion category.")
        };

        return Task.FromResult(new ConversionResponse
        {
            Category = request.Category,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit,
            OriginalValue = request.Value,
            ConvertedValue = Math.Round(result, 4)
        });
    }

    private static double ConvertUsingFactor(
        double value,
        string from,
        string to,
        Dictionary<string, double> units)
    {
        if (!units.ContainsKey(from))
            throw new ArgumentException($"Unsupported unit: {from}");

        if (!units.ContainsKey(to))
            throw new ArgumentException($"Unsupported unit: {to}");

        double baseValue = value * units[from];

        return baseValue / units[to];
    }

    private static double ConvertTemperature(
        double value,
        string from,
        string to)
    {
        if (from.Equals(to, StringComparison.OrdinalIgnoreCase))
            return value;

        // Convert to Celsius first
        double celsius = from.ToLower() switch
        {
            "celsius" => value,
            "fahrenheit" => (value - 32) * 5 / 9,
            "kelvin" => value - 273.15,
            _ => throw new ArgumentException($"Unsupported unit: {from}")
        };

        // Convert Celsius to target
        return to.ToLower() switch
        {
            "celsius" => celsius,
            "fahrenheit" => (celsius * 9 / 5) + 32,
            "kelvin" => celsius + 273.15,
            _ => throw new ArgumentException($"Unsupported unit: {to}")
        };
    }
}