using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.CustomModelAttributes;
using JournalSystemMVC.Models.ModelEnumerations;
using JournalSystemMVC.Models.ModelValidationAttributes;
using Microsoft.Owin.BuilderProperties;

namespace JournalSystemMVC.Models.People
{
    public abstract class Person
    {
        [ForeignKey("Address")]
        public virtual int AddressId { get; set; }
        [ForeignKey("ContactInformation")]
        public virtual int ContactInformationId { get; set; }

        public Address Address { get; set; }
        [DisplayName("Contact information")]
        public ContactInformation ContactInformation { get; set; }

        [Required]
        [NameValidation]
        [StringLengthValidation(Minimum = 2, Maximum = 20)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [NameValidation]
        [StringLengthValidation(Minimum = 2, Maximum = 20)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Social security number")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EuropeanDateFormatDisplay]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EuropeanDateFormatDisplay]
        [DisplayName("Registration date")]
        public DateTime Registered { get; set; }

        public Genders Gender { get; set; }

        public byte[] Avatar { get; set; }

        public string getFullName {
            get
            {
                return FirstName + " " + LastName;
            } }

    }
}
