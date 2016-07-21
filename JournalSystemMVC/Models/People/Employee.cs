using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.CustomModelAttributes;

namespace JournalSystemMVC.Models.People
{
    public class Employee : Person
    {
        public Employee()
        {
            Registered = DateTime.Now;
        }

        [Key]
        public int EmployeeId { get; set; }

        [DataType(DataType.Date)]
        [EuropeanDateFormatDisplay]
        [Required]
        public DateTime Hired { get; set; }
    }
}
