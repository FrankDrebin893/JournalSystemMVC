using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalSystemMVC.DataTransferObjects
{
    public class StatisticsDto
    {
        public StatisticsDto()
        {
            Answers = new List<AnswerDto>();
        }
        public string QuestionText { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
