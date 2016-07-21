using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ResidentData;

namespace JournalSystemMVC.Models.ViewModels
{
    public class JournalEntryViewModel
    {
        public int JournalId { get; set; }
        public JournalEntry JournalEntry { get; set; }
    }
}
