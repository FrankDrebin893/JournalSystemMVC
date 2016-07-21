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
    [DisplayName("Contact information")]
    public class ContactInformation
    {
        public ContactInformation()
        {
            PhoneNumber = "";
            Email = "";
        }

        [Key]
        public int ContactInformationId { get; set; }

        [OnlyDigitsValidation]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        // Email validator that adheres directly to the specification for email address naming. It allows for everything from ipaddress and country-code domains, to very rare characters in the username.
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }
    }
}
