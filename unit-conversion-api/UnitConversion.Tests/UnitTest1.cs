using Xunit;
using UnitConversion.Application.DTOs;
using UnitConversion.Domain.Enums;
using UnitConversion.Infrastructure.Services;

namespace UnitConversion.Tests.Services;

public class ConversionServiceTests
{
    private readonly ConversionService _service;

    public ConversionServiceTests()
    {
        _service = new ConversionService();
    }

    [Fact]
    public async Task Convert_Length_Meter_To_Foot_Should_Return_Correct_Value()
    {
        // Arrange
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Length,
            FromUnit = "Meter",
            ToUnit = "Foot",
            Value = 10
        };

        // Act
        var result = await _service.ConvertAsync(request);

        // Assert
        Assert.Equal(32.8084, result.ConvertedValue, 4);
    }

    [Fact]
    public async Task Convert_Length_Kilometer_To_Meter_Should_Return_1000()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Length,
            FromUnit = "Kilometer",
            ToUnit = "Meter",
            Value = 1
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(1000, result.ConvertedValue);
    }

    [Fact]
    public async Task Convert_Weight_Kilogram_To_Pound_Should_Return_Correct_Value()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Weight,
            FromUnit = "Kilogram",
            ToUnit = "Pound",
            Value = 1
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(2.2046, result.ConvertedValue, 4);
    }

    [Fact]
    public async Task Convert_Weight_Pound_To_Kilogram_Should_Return_Correct_Value()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Weight,
            FromUnit = "Pound",
            ToUnit = "Kilogram",
            Value = 2.20462
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(1, result.ConvertedValue, 3);
    }

    [Fact]
    public async Task Convert_Temperature_Celsius_To_Fahrenheit_Should_Return_32()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Temperature,
            FromUnit = "Celsius",
            ToUnit = "Fahrenheit",
            Value = 0
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(32, result.ConvertedValue);
    }

    [Fact]
    public async Task Convert_Temperature_Fahrenheit_To_Celsius_Should_Return_0()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Temperature,
            FromUnit = "Fahrenheit",
            ToUnit = "Celsius",
            Value = 32
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(0, result.ConvertedValue);
    }

    [Fact]
    public async Task Convert_Temperature_Celsius_To_Kelvin_Should_Return_273_15()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Temperature,
            FromUnit = "Celsius",
            ToUnit = "Kelvin",
            Value = 0
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(273.15, result.ConvertedValue, 2);
    }

    [Fact]
    public async Task Convert_Invalid_Length_Unit_Should_Throw_Exception()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Length,
            FromUnit = "ABC",
            ToUnit = "Meter",
            Value = 10
        };

        await Assert.ThrowsAsync<ArgumentException>(() =>
            _service.ConvertAsync(request));
    }

    [Fact]
    public async Task Convert_Invalid_Weight_Unit_Should_Throw_Exception()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Weight,
            FromUnit = "Kilogram",
            ToUnit = "XYZ",
            Value = 5
        };

        await Assert.ThrowsAsync<ArgumentException>(() =>
            _service.ConvertAsync(request));
    }

    [Fact]
    public async Task Convert_Invalid_Temperature_Unit_Should_Throw_Exception()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Temperature,
            FromUnit = "Celsius",
            ToUnit = "ABC",
            Value = 100
        };

        await Assert.ThrowsAsync<ArgumentException>(() =>
            _service.ConvertAsync(request));
    }

    [Fact]
    public async Task Convert_Zero_Length_Should_Return_Zero()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Length,
            FromUnit = "Meter",
            ToUnit = "Foot",
            Value = 0
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(0, result.ConvertedValue);
    }

    [Fact]
    public async Task Convert_Negative_Temperature_Should_Work()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Temperature,
            FromUnit = "Celsius",
            ToUnit = "Fahrenheit",
            Value = -40
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(-40, result.ConvertedValue);
    }

    [Fact]
    public async Task Convert_Decimal_Length_Should_Return_Correct_Value()
    {
        var request = new ConversionRequest
        {
            Category = ConversionCategory.Length,
            FromUnit = "Meter",
            ToUnit = "Centimeter",
            Value = 2.5
        };

        var result = await _service.ConvertAsync(request);

        Assert.Equal(250, result.ConvertedValue);
    }
}