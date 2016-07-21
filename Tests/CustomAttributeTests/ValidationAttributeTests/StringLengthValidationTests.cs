using System;
using JournalSystemMVC.Models.ModelValidationAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CustomAttributeTests.ValidationAttributeTests
{
    [TestClass]
    public class StringLengthValidationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "A";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "Ab";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "Abcdef";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "Abcdefg";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "AaaaaBbbbbCccccDdddd";

            var result = attribute.IsValid(testData);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var attribute = new StringLengthValidationAttribute();
            var testData = "AaaaaBbbbbCccccDddddEeeeeFffff";

            var result = attribute.IsValid(testData);

            Assert.IsFalse(result);
        }
    }
}
