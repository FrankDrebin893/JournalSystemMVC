using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalSystemMVC.Models.CustomModelAttributes
{
    public class HourMinuteDisplayFormatAttribute : DisplayFormatAttribute
    {
        public HourMinuteDisplayFormatAttribute()
        {
            DataFormatString = "{0:HH:mm}";
            ApplyFormatInEditMode = true;
        }
    }
}
