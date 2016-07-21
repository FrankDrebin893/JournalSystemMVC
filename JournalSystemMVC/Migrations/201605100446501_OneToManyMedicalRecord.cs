namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyMedicalRecord : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MedicalRecords", name: "Resident_ResidentId", newName: "MedicalRecordOwnerId");
            RenameIndex(table: "dbo.MedicalRecords", name: "IX_Resident_ResidentId", newName: "IX_MedicalRecordOwnerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MedicalRecords", name: "IX_MedicalRecordOwnerId", newName: "IX_Resident_ResidentId");
            RenameColumn(table: "dbo.MedicalRecords", name: "MedicalRecordOwnerId", newName: "Resident_ResidentId");
        }
    }
}
