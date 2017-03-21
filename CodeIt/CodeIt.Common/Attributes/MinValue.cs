using System.ComponentModel.DataAnnotations;

namespace CodeIt.Common.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly double minValue;

        public MinValueAttribute(double minValue)
        {
            this.minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            return (double)value <= this.minValue;
        }
    }
}
