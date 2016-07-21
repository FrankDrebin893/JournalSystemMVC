using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ModelValidationAttributes;

namespace JournalSystemMVC.Models
{
    public class Address
    {
        public Address()
        {
            Street = "";
            PostalCode = "";
            City = "";
        }

        [Key]
        public int AddressId { get; set; }

        [StringLengthValidation(Minimum = 2, Maximum = 40)]
        public string Street { get; set; }

        [OnlyDigitsValidation]
        [DisplayName("Postal code")]
        public string PostalCode { get; set; }

        [StringLengthValidation(Minimum = 2, Maximum = 20)]
        public string City { get; set; }
    }
}
