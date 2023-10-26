using System.ComponentModel.DataAnnotations;
using System;

namespace GenericProductAPI.Shared.Helpers
{
    public class DateNotGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateNotGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            var date = (DateTime)value;

            if (date <= comparisonValue)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
