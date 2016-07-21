using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;
using JournalSystemMVC.DataAccessLayer;
using JournalSystemMVC.DataTransferObjects;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.Statistics;
using JournalSystemMVC.Models.ViewModels;
using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IQuestionFormRepository _questionFormRepository;
        private readonly IResidentRepository _residentRepository;

        public StatisticsController(IQuestionFormRepository questionFormRepository, IResidentRepository residentRepository)
        {
            _questionFormRepository = questionFormRepository;
            _residentRepository = residentRepository;
        }

        public StatisticsController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            _questionFormRepository = new QuestionFormRepository(context);
            _residentRepository = new ResidentRepository(context);
        }

        // GET: Statistics
        public ActionResult Index()
        {
           // ViewBag.json = GetQuestionData(1003).ToString();
            return View();
        }

        public ActionResult DisplayQuestionFormData()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ViewBag.QuestionFormId = new SelectList(context.QuestionForms, "QuestionnaireId", "Title");
            ViewBag.ResidentId = new SelectList(context.Residents, "ResidentId", "getFullName");
            return View();
        }
        
        // Returns 25 most recently answered questions
        // TODO: Allow manual selection of number of returned answers
        [HttpGet]
        public JsonResult GetQuestionData(int id, int residentId)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StatisticsDto dataDto = new StatisticsDto();
            List<Answer> answers = new List<Answer>(); 
            Question question = _questionFormRepository.GetQuestionById(id, residentId);

            dataDto.QuestionText = question.QuestionText;

            string json = "";

            if (question.Answers != null)
            {
                answers = question.Answers.ToList();

                
                for (int i = 0; i <= 25; i++)
                {
                    AnswerDto answerDto = new AnswerDto()
                    {
                        y = answers[i].Score,
                        x = answers[i].ResponseDate
                    };
                    dataDto.Answers.Add(answerDto);
                }
                dataDto.Answers.Sort((x, y) => DateTime.Compare(x.x, y.x));
                json = serializer.Serialize(dataDto);
            }
            else
            {
                json = "No data found.";
            }
            
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetQuestionList(int questionFormId)
        {
            String json = "";
            QuestionListDto questionIdList = new QuestionListDto();
            List<Question> questions = _questionFormRepository.GetQuestionsByQuestionFormId(questionFormId).ToList();
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            for (int i = 0; i < questions.Count; i++)
            {
                questionIdList.QuestionIds.Add(questions[i].QuestionId);
            }

            json = serializer.Serialize(questionIdList);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }    
}

