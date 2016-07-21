using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JournalSystemMVC.Models.CustomModelAttributes
{
    public class EuropeanDateTimeFormatDisplayAttribute : DisplayFormatAttribute
    {
        public EuropeanDateTimeFormatDisplayAttribute()
        {
            DataFormatString = "{0:yyyy-MM-dd H:mm}";
            ApplyFormatInEditMode = true;
        }
    }
}