using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.MockObjects;

namespace Tests
{
    [TestClass]
    public class PersonUnitTests
    {
        // First name tests
        [TestMethod]
        public void TestPersonFirstNameA1()
        {
            var testPerson = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testPerson, null, null)
            {
                MemberName = "FirstName"
            };

            testPerson.FirstName = "B";
            Validator.TryValidateProperty(testPerson.FirstName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonFirstNameA2()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "FirstName"
            };

            testResident.FirstName = "Bo";
            Validator.TryValidateProperty(testResident.FirstName, validationContext, validationResults);


            Assert.IsTrue(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonFirstNameA3()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "FirstName"
            };

            testResident.FirstName = "Bob";
            Validator.TryValidateProperty(testResident.FirstName, validationContext, validationResults);


            Assert.IsTrue(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonFirstNameA4()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "FirstName"
            };

            testResident.FirstName = "BobbyBobbyBobbyBobby";
            Validator.TryValidateProperty(testResident.FirstName, validationContext, validationResults);


            Assert.IsTrue(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonFirstNameA5()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "FirstName"
            };

            testResident.FirstName = "BobbyBobbyBobbyBobbyBobby";
            Validator.TryValidateProperty(testResident.FirstName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonFirstNameA6()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "FirstName"
            };

            testResident.FirstName = "";
            Validator.TryValidateProperty(testResident.FirstName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonFirstNameA7()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "FirstName"
            };

            testResident.FirstName = "1234";
            Validator.TryValidateProperty(testResident.FirstName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        // Last name unit tests
        [TestMethod]
        public void TestPersonLastNameB1()
        {
            var testPerson = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testPerson, null, null)
            {
                MemberName = "LastName"
            };

            testPerson.LastName = "T";
            Validator.TryValidateProperty(testPerson.LastName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonLastNameB2()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "LastName"
            };

            testResident.LastName = "Ta";
            Validator.TryValidateProperty(testResident.LastName, validationContext, validationResults);


            Assert.IsTrue(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonLastNameB3()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "LastName"
            };

            testResident.LastName = "Tab";
            Validator.TryValidateProperty(testResident.LastName, validationContext, validationResults);


            Assert.IsTrue(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonLastNameB4()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "LastName"
            };

            testResident.LastName = "TableTableTableTable";
            Validator.TryValidateProperty(testResident.LastName, validationContext, validationResults);


            Assert.IsTrue(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonLastNameB5()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "LastName"
            };

            testResident.LastName = "TableTableTableTableTable";
            Validator.TryValidateProperty(testResident.LastName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonLastNameB6()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "LastName"
            };

            testResident.LastName = "";
            Validator.TryValidateProperty(testResident.LastName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

        [TestMethod]
        public void TestPersonLastNameB7()
        {
            var testResident = new MockPerson();
            var validationResults = new BindingList<ValidationResult>();
            var validationContext = new ValidationContext(testResident, null, null)
            {
                MemberName = "LastName"
            };

            testResident.LastName = "1234";
            Validator.TryValidateProperty(testResident.LastName, validationContext, validationResults);


            Assert.IsFalse(validationResults.Count == 0);
        }

    }
}
