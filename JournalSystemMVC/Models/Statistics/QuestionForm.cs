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

namespace JournalSystemMVC.Models.Statistics
{
    public class QuestionForm
    {
        [Key]
        public int QuestionnaireId { get; set; }

        [Required]
        [StringLengthValidation(Minimum = 2, Maximum = 60)]
        public string Title { get; set; }

        [StringLengthValidation(Minimum = 2, Maximum = 140)]
        public string Description { get; set; }
        
        public virtual ICollection<Question> Questions { get; set; }
    }
}
