namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyMedicalRecordAddedForeignKeyProp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MedicalRecords", name: "AdministeringDoctor_ContactId", newName: "AdministeringDoctorId");
            RenameIndex(table: "dbo.MedicalRecords", name: "IX_AdministeringDoctor_ContactId", newName: "IX_AdministeringDoctorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MedicalRecords", name: "IX_AdministeringDoctorId", newName: "IX_AdministeringDoctor_ContactId");
            RenameColumn(table: "dbo.MedicalRecords", name: "AdministeringDoctorId", newName: "AdministeringDoctor_ContactId");
        }
    }
}
