using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.Models.Statistics
{
    // Response to question that provides 
    public class Answer
    {
        [Key]
        public int ResponseId { get; set; }
        [ForeignKey("Question")]
        [ScriptIgnore]
        public int QuestionId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Resident")]
        public int ResidentId { get; set; }

        public int Score { get; set; }
        public DateTime ResponseDate { get; set; }
        [ScriptIgnore]
        public Question Question { get; set; }
        public Employee Employee { get; set; }
        public Resident Resident { get; set; }
    }
}
