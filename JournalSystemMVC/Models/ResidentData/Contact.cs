using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ModelEnumerations;
using JournalSystemMVC.Models.ModelValidationAttributes;
using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.Models.ResidentData
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        [ForeignKey("ContactInformation")]
        public int ContactInformationId { get; set; }

        [Required]
        [StringLengthValidation(Minimum = 2, Maximum = 30)]
        [NameValidation]
        public string Name { get; set; }
        public Address Address { get; set; }
        public ContactInformation ContactInformation { get; set; }
        [Required]
        public ContactTypes ContactType { get; set; }

    }
}
