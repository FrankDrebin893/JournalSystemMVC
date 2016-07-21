using JournalSystemMVC.Models.People;
using JournalSystemMVC.Models.ResidentData;
using JournalSystemMVC.Models.Statistics;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.Medicine;

namespace JournalSystemMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<QuestionForm> QuestionForms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<PrescriptionMedicine> Prescriptions { get; set; }
        public DbSet<ProReNataMedicine> PrnMedicines { get; set; }
        public DbSet<MedicineAdministrationTime> MedicineAdministrationTimes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
