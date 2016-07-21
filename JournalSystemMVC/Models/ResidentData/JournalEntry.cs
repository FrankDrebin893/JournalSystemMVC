using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.CustomModelAttributes;
using JournalSystemMVC.Models.ModelValidationAttributes;
using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.Models.ResidentData
{
    public class JournalEntry
    {
        public JournalEntry()
        {
            EntryDate = DateTime.Now;
        }

        [Key]
        public int JournalEntryId { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [ForeignKey("Journal")]
        public int JournalId { get; set; }

        [Required]
        [StringLengthValidation(Minimum = 10, Maximum = 500)]
        public string EntryText { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EuropeanDateTimeFormatDisplay]
        public DateTime EntryDate { get; set; }
        
        public Employee Author { get; set; }

        public Journal Journal { get; set; }
    }
}
