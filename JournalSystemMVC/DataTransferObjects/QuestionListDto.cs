using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalSystemMVC.DataTransferObjects
{
    public class QuestionListDto
    {
        public QuestionListDto()
        {
            QuestionIds = new List<int>();
        }
        public List<int> QuestionIds { get; set; }
    }
}
