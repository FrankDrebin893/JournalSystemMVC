namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyMedicalRecordRenaming : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MedicalRecords", name: "MedicalRecordOwnerId", newName: "MedicalRecordOwnerResidentId");
            RenameIndex(table: "dbo.MedicalRecords", name: "IX_MedicalRecordOwnerId", newName: "IX_MedicalRecordOwnerResidentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MedicalRecords", name: "IX_MedicalRecordOwnerResidentId", newName: "IX_MedicalRecordOwnerId");
            RenameColumn(table: "dbo.MedicalRecords", name: "MedicalRecordOwnerResidentId", newName: "MedicalRecordOwnerId");
        }
    }
}
