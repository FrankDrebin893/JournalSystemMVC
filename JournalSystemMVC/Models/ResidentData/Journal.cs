using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.Models.ResidentData
{
    public class Journal
    {
        [Key]
        public int JournalId { get; set; }

        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Profile description cannot exceed 1000 characters.")]
        public string ProfileDescription { get; set; }
        
        public virtual ICollection<JournalEntry> JournalEntries { get; set; }
    }
}
