using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ResidentData;

namespace JournalSystemMVC.Models.ViewModels
{
    public class JournalViewModel
    {
        public Journal Journal { get; set; }
        public IEnumerable<JournalEntry> JournalEntries { get; set; }
        public string ResidentName { get; set; }
        public int ResidentId { get; set; }
    }
}
