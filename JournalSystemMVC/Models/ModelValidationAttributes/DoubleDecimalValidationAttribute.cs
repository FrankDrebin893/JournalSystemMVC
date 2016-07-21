using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JournalSystemMVC.Models.ModelValidationAttributes
{
    public class DoubleDecimalValidationAttribute : ValidationAttribute
    {
        public DoubleDecimalValidationAttribute()
        {
            ErrorMessage = "Must be a positive whole number with zero or two decimal points.";
        }

        // Matches positive whole numbers with exactly zero or two decimal points if a ',' is present. Useful for checking currency amounts, such 5 or 5.00 or 5.25. 
        public override bool IsValid(object value)
        {
            const string decimalRegex = @"^\d+(?:\.\d{0,2})?$";
            
            var regex = new Regex(decimalRegex);

            if (value != null)
            {
                var doubleValue = value.ToString();
                return regex.IsMatch(doubleValue);
            }

            return false;
        }
    }
}
