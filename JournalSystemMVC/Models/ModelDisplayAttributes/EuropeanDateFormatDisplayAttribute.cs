using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JournalSystemMVC.Models.CustomModelAttributes
{
    public class EuropeanDateFormatDisplayAttribute : DisplayFormatAttribute
    {
        public EuropeanDateFormatDisplayAttribute()
        {
            DataFormatString = "{0:yyyy-MM-dd}";
            ApplyFormatInEditMode = true;
        }
    }
}