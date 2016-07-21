using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JournalSystemMVC.Models.ModelValidationAttributes
{
    public class OnlyDigitsValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Accepts only digits.
            const string numberRegex = @"^[0-9]*$";
            
            var regex = new Regex(numberRegex);
            if (value != null)
            {
                string input = value.ToString();
                return regex.IsMatch(input);
            }

            return false;
        }
    }
}
