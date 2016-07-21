using System;
using System.ComponentModel.DataAnnotations;
using JournalSystemMVC.Models.CustomModelAttributes;

namespace JournalSystemMVC.Models.Medicine
{
    public class MedicineAdministrationTime
    {
        [Key]
        public int MedicineAdministrationTimeId { get; set; }
        [DataType(DataType.Time)]
        [HourMinuteDisplayFormat]
        public DateTime AdministrationTime { get; set; }
    }
}
