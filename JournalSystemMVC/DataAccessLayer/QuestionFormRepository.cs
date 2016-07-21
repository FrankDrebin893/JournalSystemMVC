using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.Statistics;

namespace JournalSystemMVC.DataAccessLayer
{
    public class QuestionFormRepository : IQuestionFormRepository
    {
        private readonly ApplicationDbContext _context;

       

        public QuestionFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public QuestionFormRepository()
        {
            _context = new ApplicationDbContext();
        }

         public IEnumerable<QuestionForm> GetQuestionForms()
        {
            return _context.QuestionForms;
        }

        public void AddQuestionForm(QuestionForm questionForm)
        {
            _context.QuestionForms.Add(questionForm);
        }

        public void DeleteQuestionForm(int id)
        {
            var questionForm = _context.QuestionForms.Find(id);
            _context.QuestionForms.Remove(questionForm);
        }

        public QuestionForm GetQuestionFormById(int id)
        {
            return _context.QuestionForms.Find(id);
        }

        public Question GetQuestionById(int id)
        {
            //return _context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.QuestionId == id);
            return _context.Questions.Include(q=>q.Answers).First(q => q.QuestionId == id);
        }

        public Question GetQuestionById(int id, int residentId)
        {
            Question question = _context.Questions.First(q => q.QuestionId == id);
            //return _context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.QuestionId == id);
            //return _context.Questions.Include(q => q.Answers).First(q => q.QuestionId == id);
            question.Answers = _context.Answers.Where((a => a.QuestionId == id && a.ResidentId == residentId)).ToList();
            return question;
        }

        public IEnumerable<Question> GetQuestionsByQuestionFormId(int id)
        {
            return _context.Questions.Where(q => q.QuestionFormId == id);
        } 

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
