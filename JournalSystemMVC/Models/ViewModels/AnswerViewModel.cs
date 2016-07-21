using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.Statistics;

namespace JournalSystemMVC.Models.ViewModels
{
    public class AnswerViewModel
    {
        public IEnumerable<Answer> Answers { get; set; } 
        public int EmployeeId { get; set; }
        public int ResidentId { get; set; }
    }
}
