using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ModelValidationAttributes;

namespace JournalSystemMVC.Models.Statistics
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [ForeignKey("QuestionForm")]
        public int QuestionFormId { get; set; }
        [StringLengthValidation(Minimum = 6, Maximum = 80)]
        public string QuestionText { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public QuestionForm QuestionForm { get; set; }
    }
}
