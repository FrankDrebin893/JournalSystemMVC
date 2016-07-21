using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JournalSystemMVC.DataAccessLayer;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.Statistics;
using JournalSystemMVC.Models.ViewModels;

namespace JournalSystemMVC.Controllers
{
    public class DataAnalyticsController : Controller
    {
        private readonly IQuestionFormRepository _questionFormRepository;
        private readonly IAnswerRepository _answerRepository;

        public DataAnalyticsController()
        {
            var context = new ApplicationDbContext();
            _questionFormRepository = new QuestionFormRepository(context);
            _answerRepository = new AnswerRepository(context);
        }

        public ActionResult Index()
        {
            return View(_questionFormRepository.GetQuestionForms());
        }

        public DataAnalyticsController(IQuestionFormRepository questionFormRepository)
        {
            _questionFormRepository = questionFormRepository;
        }

        public ActionResult CreateQuestionForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestionForm([Bind(Include = "QuestionnaireId, Title, Description, Questions")]QuestionForm questionForm)
        {
            if (ModelState.IsValid)
            {
                _questionFormRepository.AddQuestionForm(questionForm);
                _questionFormRepository.Save();
            }
            return View();
        }

        public PartialViewResult BlankEditorRow()
        {
            return PartialView("Editors/_QuestionEditorRow", new Question());
        }

        public ActionResult FillQuestionForm(int id)
        {
            var answerVm = new AnswerViewModel();
            var questionsList = _questionFormRepository.GetQuestionsByQuestionFormId(id).ToList();
            var answersList = new List<Answer>();
            for (int i = 0; i < questionsList.Count(); i++)
            {
                var question = questionsList[i];
                var newAnswer = new Answer()
                {
                    QuestionId = question.QuestionId,
                    Question = question
                    
                };
                answersList.Add(newAnswer);
            }

            answerVm.Answers = answersList;
            return View(answerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillQuestionForm([Bind(Include = "EmployeeId, ResidentId, Answers")]AnswerViewModel answerVm)
        {
            var answerDate = DateTime.Now;
            var employeeId = answerVm.EmployeeId;
            var residentId = answerVm.ResidentId;

            foreach (var answer in answerVm.Answers)
            {
                answer.ResponseDate = answerDate;
                answer.ResidentId = residentId;
                answer.EmployeeId = employeeId;
                
                    _answerRepository.AddAnswer(answer);
                    _answerRepository.Save();
            }
            return RedirectToAction("Index");
        }
    }
}