namespace UnitConversion.Domain.Models
{
    public class UnitDefinition
    {
        public string Name { get; set; } = string.Empty;

        public double Factor { get; set; }

        public double Offset { get; set; }
    }
}