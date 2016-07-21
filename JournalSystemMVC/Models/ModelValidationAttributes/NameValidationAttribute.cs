using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JournalSystemMVC.Models.ModelValidationAttributes
{
    public class NameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string name = value as string;
            const string nameRegex = @"^([ \u00c0-\u01ffa-zA-Z'\-])+$";
            var regex = new Regex(nameRegex);

            if (value == null) return false;

            return regex.IsMatch(name);
        }
    }
}
