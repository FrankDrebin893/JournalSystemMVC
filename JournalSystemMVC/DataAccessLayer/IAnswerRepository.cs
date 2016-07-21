using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.Statistics;

namespace JournalSystemMVC.DataAccessLayer
{
    public interface IAnswerRepository
    {
        void AddAnswer(Answer answer);
        IEnumerable<Answer> GetAnswersByResidentId(int residentId, int questionFormId);
        void Save();
    }
}
