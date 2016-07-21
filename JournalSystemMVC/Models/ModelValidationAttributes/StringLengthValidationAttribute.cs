using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalSystemMVC.Models.ModelValidationAttributes
{
    public class StringLengthValidationAttribute : ValidationAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public StringLengthValidationAttribute()
        {
            this.Minimum = 6;
            this.Maximum = 20;
            ErrorMessage = "Must be between " + this.Minimum + " and " + this.Maximum + " characters long.";
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                int length = strValue.Length;
                return length >= this.Minimum && length <= this.Maximum;
            }
            return true;
        }
    }
}
