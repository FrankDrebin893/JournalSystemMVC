using System;
using JournalSystemMVC.Models.ModelValidationAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CustomAttributeTests.ValidationAttributeTests
{
    [TestClass]
    public class NameValidationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var attribute = new NameValidationAttribute();
            string testData = "";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var attribute = new NameValidationAttribute();
            string testData = "%@";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var attribute = new NameValidationAttribute();
            string testData = "Bo";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var attribute = new NameValidationAttribute();
            string testData = "Bobby Lé'Fevre";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var attribute = new NameValidationAttribute();
            string testData = "1234";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var attribute = new NameValidationAttribute();
            string testData = "String-with-dash";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }
    }
}
