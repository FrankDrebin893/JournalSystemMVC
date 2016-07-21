using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.Medicine;
using JournalSystemMVC.Models.ModelEnumerations;
using JournalSystemMVC.Models.People;
using JournalSystemMVC.Models.ResidentData;
using JournalSystemMVC.Models.Statistics;

namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JournalSystemMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JournalSystemMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Add resident to database complete with medical record, medicines, journal

            // Contacts
            /*
            var contactOne = new Contact()
            {
                Name = "Borge Hansen",
                ContactInformation = new ContactInformation()
                {
                    PhoneNumber = "99228833",
                    Email = "one@contact.dk"
                },
                Address = new Address()
                {
                    City = "Praestoe",
                    PostalCode = "4720",
                    Street = "Naebvej 21"
                },
                ContactType = ContactTypes.Friend
            };

            var contactTwo = new Contact()
            {
                Name = "Vaerkstedet",
                Address = new Address()
                {
                    City = "Naestved",
                    PostalCode = "4735",
                    Street = "Naestved vej"
                },
                ContactInformation = new ContactInformation()
                {
                    PhoneNumber = "23981723",
                    Email = "two@contact.dk"
                }
            };

            // Health data for resident
            var doctorAddress = new Address()
            {
                City = "Nykøbing Falster",
                PostalCode = "4750",
                Street = "Nykøbing Falster"
            };

            var doctorContactInfo = new ContactInformation()
            {
                Email = "doctorhansen@gmail.com",
                PhoneNumber = "11223344"
            };

            var doctor = new Contact()
            {
                Name = "Per",
                Address = doctorAddress,
                ContactInformation = doctorContactInfo,
                ContactType = ContactTypes.Doctor
            };

            var administrationTime = new MedicineAdministrationTime()
            {
                AdministrationTime = DateTime.Now
            };

            var administrationTimeTwo = new MedicineAdministrationTime()
            {
                AdministrationTime = DateTime.Now
            };

            List<MedicineAdministrationTime> administrationTimes = new List<MedicineAdministrationTime>();
            administrationTimes.Add(administrationTime);
            administrationTimes.Add(administrationTimeTwo);

            var prescription = new PrescriptionMedicine()
            {
                AdministrationReason = "Sore back",
                Dosage = "2",
                Description = "Administrate twice a day",
                PreparationName = "Prescription X",
                DispenserType = "Pill",
                AdministrationTimes = administrationTimes
            };

            var pnMedicine = new ProReNataMedicine()
            {
                Description = "Take one pill for headache",
                PreparationName = "Panodil",
                AdministrationReason = "Headache",
                DispenserType = "Pill",
                MaxTimesPerDay = 2,
                Dosage = "1",
                SideEffects = "None of consequence"
            };

            List<ProReNataMedicine> pnMedicineList = new List<ProReNataMedicine> { pnMedicine };

            List<PrescriptionMedicine> prescriptions = new List<PrescriptionMedicine> { prescription };

            var medicalRecord = new MedicalRecord()
            {
                Height = 185,
                WaistLine = 57,
                Weight = 85,
                PrnMedicines = pnMedicineList,
                Prescriptions = prescriptions,
                AdministeringDoctor = doctor,
                Created = DateTime.Now
            };

            // Journal data
            var authorContactInfo = new ContactInformation()
            {
                PhoneNumber = "55667744",
                Email = "michael@madsen.dk"
            };

            var authorAddress = new Address()
            {
                City = "Faxe",
                PostalCode = "2313",
                Street = "Faxevej"
            };

            var entryAuthor = new Employee()
            {
                FirstName = "Michael",
                LastName = "Madsen",
                SocialSecurityNumber = "231342-1231",
                Address = authorAddress,
                ContactInformation = authorContactInfo,
                Gender = Genders.Male,
                Registered = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Hired = DateTime.Now
            };

            var journalEntry = new JournalEntry()
            {
                EntryDate = DateTime.Now,
                EntryText = "Lorem ipsum dolor sit amet, nisl sed, nec integer. Adipiscing proin sed. Leo turpis diam, pulvinar wisi faucibus, suspendisse ac, libero nibh metus urna, taciti cras ut mus massa. Arcu quis urna faucibus iaculis placerat, blandit facilisi et. Quisque eget venenatis, tincidunt vel semper curabitur dui et a, vitae fermentum fusce senectus magna malesuada laoreet, non tellus aenean ligula nec.",
                Author = entryAuthor
            };

            var journalEntryTwo = new JournalEntry()
            {
                EntryDate = DateTime.Now,
                EntryText = "Praesent justo porttitor enim bibendum risus mattis. Nunc velit, volutpat nec, vitae lacus tincidunt nunc nam. Elit ultricies purus cursus, varius ligula purus at suscipit, risus tincidunt aptent morbi. Reprehenderit suspendisse vehicula orci vehicula pede nec. Nulla dignissim proin, fusce consequat faucibus malesuada fames dolor, massa praesent quisque sed quis.",
                Author = entryAuthor
            };

            List<JournalEntry> entries = new List<JournalEntry>();
            entries.Add(journalEntry);
            entries.Add(journalEntryTwo);

            var journal = new Journal()
            {
                ProfileDescription = "This is a test journal",
                JournalEntries = entries
            };

            // Resident's profile
            List<Contact> contacts = new List<Contact>();
            contacts.Add(doctor);
            contacts.Add(contactOne);
            contacts.Add(contactTwo);

            var address = new Address()
            {
                City = "Gedser",
                PostalCode = "4700",
                Street = "Gedser Landevej"
            };

            var contactInformation = new ContactInformation()
            {
                Email = "john@hurt.dk",
                PhoneNumber = "22773366"
            };

            var resident = new Resident()
            {
                FirstName = "John",
                LastName = "Hurt",
                ActingMunicipality = "Guldborg Sund",
                PayingMunicipality = "Guldborg Sund",
                BirthPlace = "Copenhagen",
                DateOfBirth = DateTime.Now,
                MovedIn = DateTime.Now,
                Gender = Genders.Male,
                CivilStatus = CivilStatuses.Single,
                OfAge = true,
                Journal = journal,
                Registered = DateTime.Now,
                SocialSecurityNumber = "231232-3921",
                Address = address,
                ContactInformation = contactInformation,
                Contacts = contacts,
                MedicalRecords = new List<MedicalRecord>()
            };

            context.Residents.Add(resident);
            this.SaveChanges(context);

            resident.MedicalRecords.Add(medicalRecord);
            context.Residents.Attach(resident);
            context.Entry(resident).State = EntityState.Modified;
            this.SaveChanges(context);
            */
            // Add entrydata for answers to questions. Commented to avoid flooding database
            
            var date = new DateTime(2010, 1, 1);
            var random = new Random();
            Answer answerOne = new Answer()
            {
                ResidentId = 2,
                EmployeeId = 1,
                QuestionId = 4,
                Score = 2,
                ResponseDate = date
            };

            Answer answerTwo = new Answer()
            {
                ResidentId = 2,
                EmployeeId = 1,
                QuestionId = 5,
                Score = 3,
                ResponseDate = date
            };
            /*
            Answer answerThree = new Answer()
            {
                ResidentId = 2,
                EmployeeId = 1,
                QuestionId = 3,
                Score = 3,
                ResponseDate = date
            };*/

            for (var i = 0; i <= 400; i++)
            {
                date = date.AddDays(1);
                answerOne.Score = random.Next(1, 6);
                answerTwo.Score = random.Next(1, 6);
              //  answerThree.Score = random.Next(1,6);
                answerOne.ResponseDate = date;
                answerTwo.ResponseDate = date;
              //  answerThree.ResponseDate = date;
                context.Answers.Add(answerOne);
                context.Answers.Add(answerTwo);
              //  context.Answers.Add(answerThree);
                context.SaveChanges();
            }
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
