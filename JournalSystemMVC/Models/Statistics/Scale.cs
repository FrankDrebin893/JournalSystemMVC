using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalSystemMVC.Models.Statistics
{
    public class Scale
    {
        [Key]
        public int ScaleId { get; set; }
        [ForeignKey("Questionnaire")]
        public int QuestionnaireId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Your question must be between 6 and 30 characters.")]
        public string Question { get; set; }

        [Range(1, 5, ErrorMessage = "The score must be between equal to or between 1 and 5")]
        public int? Score { get; set; }

        public QuestionForm Questionnaire { get; set; }
    }
}
