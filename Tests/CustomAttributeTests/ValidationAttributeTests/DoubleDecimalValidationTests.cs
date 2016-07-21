using System;
using JournalSystemMVC.Models.ModelValidationAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CustomAttributeTests.ValidationAttributeTests
{
    [TestClass]
    public class DoubleDecimalValidationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "12.23";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "12,23";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "12.3";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "12380925.23";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "12";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "Non-digit-string";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var attribute = new DoubleDecimalValidationAttribute();
            string testData = "12 23";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }
    }
}
