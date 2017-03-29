using System;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.Common.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int minValue;

        public MinValueAttribute(int minValue)
        {
            this.minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            double castedValue = Convert.ToDouble(value);
            return castedValue >= this.minValue;
        }
    }
}
