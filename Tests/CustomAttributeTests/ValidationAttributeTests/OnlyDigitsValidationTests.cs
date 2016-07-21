using System;
using JournalSystemMVC.Models.ModelValidationAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CustomAttributeTests.ValidationAttributeTests
{
    [TestClass]
    public class OnlyDigitsValidationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var attribute = new OnlyDigitsValidationAttribute();
            var testData = "213213";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var attribute = new OnlyDigitsValidationAttribute();
            var testData = "2132.13";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var attribute = new OnlyDigitsValidationAttribute();
            var testData = "213,213";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var attribute = new OnlyDigitsValidationAttribute();
            var testData = "AaZz";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var attribute = new OnlyDigitsValidationAttribute();
            var testData = "@£$€";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }
    }
}
