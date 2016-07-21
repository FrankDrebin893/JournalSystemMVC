using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ResidentData;

namespace JournalSystemMVC.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<JournalEntry> JournalEntries { get; set; }
        public int EntriesPerPage { get; set; }
        public int PageNum { get; set; }
    }
}
