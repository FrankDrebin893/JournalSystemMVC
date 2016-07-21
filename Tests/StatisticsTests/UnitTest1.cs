using System;
using System.Web.Mvc;
using JournalSystemMVC.Controllers;
using JournalSystemMVC.DataAccessLayer;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.StatisticsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StatisticsController controller = new StatisticsController();
            JsonResult result = controller.GetQuestionData(1003);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            IQuestionFormRepository questionFormRepository = new QuestionFormRepository(new ApplicationDbContext());
            var result = questionFormRepository.GetQuestionById(1003);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            IQuestionFormRepository questionFormRepository = new QuestionFormRepository();
            var result = questionFormRepository.GetQuestionById(1003, 19);
            Assert.IsNotNull(result);
        }
    }
}
