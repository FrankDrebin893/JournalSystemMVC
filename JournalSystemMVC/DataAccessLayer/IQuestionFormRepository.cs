using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.Statistics;

namespace JournalSystemMVC.DataAccessLayer
{
    public interface IQuestionFormRepository
    {
        IEnumerable<QuestionForm> GetQuestionForms(); 
        void AddQuestionForm(QuestionForm questionForm);
        void DeleteQuestionForm(int id);
        QuestionForm GetQuestionFormById(int id);
        Question GetQuestionById(int id);
        Question GetQuestionById(int id, int residentId);
        IEnumerable<Question> GetQuestionsByQuestionFormId(int id); 
        void Save();
    }
}
