using UnitConversion.Domain.Enums;

namespace UnitConversion.Application.DTOs
{
    public class ConversionResponse
    {
        public ConversionCategory Category { get; set; }

        public string FromUnit { get; set; } = string.Empty;

        public string ToUnit { get; set; } = string.Empty;

        public double OriginalValue { get; set; }

        public double ConvertedValue { get; set; }
    }
}