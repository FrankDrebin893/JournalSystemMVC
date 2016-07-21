using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.CustomModelAttributes;
using JournalSystemMVC.Models.Medicine;
using JournalSystemMVC.Models.ModelEnumerations;
using JournalSystemMVC.Models.ModelValidationAttributes;
using JournalSystemMVC.Models.ResidentData;
using JournalSystemMVC.Models.Statistics;

namespace JournalSystemMVC.Models.People
{
    public class Resident : Person
    {
        public Resident()
        {
            Registered = DateTime.Now;
        }

        [Key]
        public int ResidentId { get; set; }
        [ForeignKey("Journal")]
        public virtual int JournalId { get; set; }
        [DisplayName("Civil status")]
        public CivilStatuses CivilStatus { get; set; }

        [Required]
        [StringLengthValidation]
        [DisplayName("Of age")]
        public bool OfAge { get; set; }

        [Required]
        [StringLengthValidation]
        [DisplayName("Paying municipality")]
        public string PayingMunicipality { get; set; }

        [Required]
        [StringLengthValidation]
        [DisplayName("Acting municipality")]
        public string ActingMunicipality { get; set; }

        [StringLengthValidation]
        [DisplayName("Place of birth")]
        public string BirthPlace { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EuropeanDateFormatDisplay]
        [DisplayName("Moving in date")]
        public DateTime MovedIn { get; set; }
        
        public Journal Journal { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        
    }
}
