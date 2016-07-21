namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        ContactInformationId = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactInformationId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        ContactInformationId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        ContactType = c.Int(nullable: false),
                        Resident_ResidentId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.ContactInformations", t => t.ContactInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Residents", t => t.Resident_ResidentId)
                .Index(t => t.AddressId)
                .Index(t => t.ContactInformationId)
                .Index(t => t.Resident_ResidentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Hired = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ContactInformationId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SocialSecurityNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Registered = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.ContactInformations", t => t.ContactInformationId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.ContactInformationId);
            
            CreateTable(
                "dbo.JournalEntries",
                c => new
                    {
                        JournalEntryId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        EntryText = c.String(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Journal_JournalId = c.Int(),
                    })
                .PrimaryKey(t => t.JournalEntryId)
                .ForeignKey("dbo.Employees", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Journals", t => t.Journal_JournalId)
                .Index(t => t.AuthorId)
                .Index(t => t.Journal_JournalId);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        JournalId = c.Int(nullable: false, identity: true),
                        ProfileDescription = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.JournalId);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        MedicalRecordId = c.Int(nullable: false, identity: true),
                        Weight = c.Double(),
                        Height = c.Double(),
                        WaistLine = c.Double(),
                        Created = c.DateTime(nullable: false),
                        AdministeringDoctor_ContactId = c.Int(),
                        Resident_ResidentId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicalRecordId)
                .ForeignKey("dbo.Contacts", t => t.AdministeringDoctor_ContactId)
                .ForeignKey("dbo.Residents", t => t.Resident_ResidentId)
                .Index(t => t.AdministeringDoctor_ContactId)
                .Index(t => t.Resident_ResidentId);
            
            CreateTable(
                "dbo.PrescriptionMedicines",
                c => new
                    {
                        PrescriptionMedicineId = c.Int(nullable: false, identity: true),
                        PreparationName = c.String(nullable: false),
                        Description = c.String(),
                        Dosage = c.String(),
                        DispenserType = c.String(),
                        AdministrationReason = c.String(),
                        MedicalRecord_MedicalRecordId = c.Int(),
                    })
                .PrimaryKey(t => t.PrescriptionMedicineId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecord_MedicalRecordId)
                .Index(t => t.MedicalRecord_MedicalRecordId);
            
            CreateTable(
                "dbo.MedicineAdministrationTimes",
                c => new
                    {
                        MedicineAdministrationTimeId = c.Int(nullable: false, identity: true),
                        AdministrationTime = c.DateTime(nullable: false),
                        PrescriptionMedicine_PrescriptionMedicineId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicineAdministrationTimeId)
                .ForeignKey("dbo.PrescriptionMedicines", t => t.PrescriptionMedicine_PrescriptionMedicineId)
                .Index(t => t.PrescriptionMedicine_PrescriptionMedicineId);
            
            CreateTable(
                "dbo.ProReNataMedicines",
                c => new
                    {
                        MedicineProNecessitateId = c.Int(nullable: false, identity: true),
                        MaxTimesPerDay = c.Int(),
                        SideEffects = c.String(maxLength: 40),
                        PreparationName = c.String(nullable: false),
                        Description = c.String(),
                        Dosage = c.String(),
                        DispenserType = c.String(),
                        AdministrationReason = c.String(),
                        MedicalRecord_MedicalRecordId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicineProNecessitateId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecord_MedicalRecordId)
                .Index(t => t.MedicalRecord_MedicalRecordId);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        QuestionnaireId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        QuestionnaireName = c.String(nullable: false),
                        Comment = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionnaireId)
                .ForeignKey("dbo.Employees", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Scales",
                c => new
                    {
                        ScaleId = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 30),
                        Score = c.Int(),
                        Questionnaire_QuestionnaireId = c.Int(),
                    })
                .PrimaryKey(t => t.ScaleId)
                .ForeignKey("dbo.Questionnaires", t => t.Questionnaire_QuestionnaireId)
                .Index(t => t.Questionnaire_QuestionnaireId);
            
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        ResidentId = c.Int(nullable: false, identity: true),
                        JournalId = c.Int(nullable: false),
                        CivilStatus = c.Int(nullable: false),
                        OfAge = c.Boolean(nullable: false),
                        PayingMunicipality = c.String(nullable: false),
                        ActingMunicipality = c.String(nullable: false),
                        BirthPlace = c.String(),
                        MovedIn = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ContactInformationId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SocialSecurityNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Registered = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResidentId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.ContactInformations", t => t.ContactInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Journals", t => t.JournalId, cascadeDelete: true)
                .Index(t => t.JournalId)
                .Index(t => t.AddressId)
                .Index(t => t.ContactInformationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MedicalRecords", "Resident_ResidentId", "dbo.Residents");
            DropForeignKey("dbo.Residents", "JournalId", "dbo.Journals");
            DropForeignKey("dbo.Contacts", "Resident_ResidentId", "dbo.Residents");
            DropForeignKey("dbo.Residents", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Residents", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Scales", "Questionnaire_QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Questionnaires", "AuthorId", "dbo.Employees");
            DropForeignKey("dbo.ProReNataMedicines", "MedicalRecord_MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.PrescriptionMedicines", "MedicalRecord_MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicineAdministrationTimes", "PrescriptionMedicine_PrescriptionMedicineId", "dbo.PrescriptionMedicines");
            DropForeignKey("dbo.MedicalRecords", "AdministeringDoctor_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.JournalEntries", "Journal_JournalId", "dbo.Journals");
            DropForeignKey("dbo.JournalEntries", "AuthorId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "ContactInformationId", "dbo.ContactInformations");
            DropForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Residents", new[] { "ContactInformationId" });
            DropIndex("dbo.Residents", new[] { "AddressId" });
            DropIndex("dbo.Residents", new[] { "JournalId" });
            DropIndex("dbo.Scales", new[] { "Questionnaire_QuestionnaireId" });
            DropIndex("dbo.Questionnaires", new[] { "AuthorId" });
            DropIndex("dbo.ProReNataMedicines", new[] { "MedicalRecord_MedicalRecordId" });
            DropIndex("dbo.MedicineAdministrationTimes", new[] { "PrescriptionMedicine_PrescriptionMedicineId" });
            DropIndex("dbo.PrescriptionMedicines", new[] { "MedicalRecord_MedicalRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "Resident_ResidentId" });
            DropIndex("dbo.MedicalRecords", new[] { "AdministeringDoctor_ContactId" });
            DropIndex("dbo.JournalEntries", new[] { "Journal_JournalId" });
            DropIndex("dbo.JournalEntries", new[] { "AuthorId" });
            DropIndex("dbo.Employees", new[] { "ContactInformationId" });
            DropIndex("dbo.Employees", new[] { "AddressId" });
            DropIndex("dbo.Contacts", new[] { "Resident_ResidentId" });
            DropIndex("dbo.Contacts", new[] { "ContactInformationId" });
            DropIndex("dbo.Contacts", new[] { "AddressId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Residents");
            DropTable("dbo.Scales");
            DropTable("dbo.Questionnaires");
            DropTable("dbo.ProReNataMedicines");
            DropTable("dbo.MedicineAdministrationTimes");
            DropTable("dbo.PrescriptionMedicines");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Journals");
            DropTable("dbo.JournalEntries");
            DropTable("dbo.Employees");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactInformations");
            DropTable("dbo.Addresses");
        }
    }
}
