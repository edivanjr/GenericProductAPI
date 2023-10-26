using System.ComponentModel.DataAnnotations;
using System;

namespace GenericProductAPI.Shared.Helpers
{
    public class DateNotInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = (DateTime)value;
            return date >= DateTime.Now;
        }
    }
}
