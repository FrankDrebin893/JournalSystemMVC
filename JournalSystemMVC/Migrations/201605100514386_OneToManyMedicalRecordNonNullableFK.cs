namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyMedicalRecordNonNullableFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalRecords", "AdministeringDoctorId", "dbo.Contacts");
            DropForeignKey("dbo.MedicalRecords", "MedicalRecordOwnerResidentId", "dbo.Residents");
            DropIndex("dbo.MedicalRecords", new[] { "MedicalRecordOwnerResidentId" });
            DropIndex("dbo.MedicalRecords", new[] { "AdministeringDoctorId" });
            AlterColumn("dbo.MedicalRecords", "MedicalRecordOwnerResidentId", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalRecords", "AdministeringDoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalRecords", "MedicalRecordOwnerResidentId");
            CreateIndex("dbo.MedicalRecords", "AdministeringDoctorId");
            AddForeignKey("dbo.MedicalRecords", "AdministeringDoctorId", "dbo.Contacts", "ContactId", cascadeDelete: false);
            AddForeignKey("dbo.MedicalRecords", "MedicalRecordOwnerResidentId", "dbo.Residents", "ResidentId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "MedicalRecordOwnerResidentId", "dbo.Residents");
            DropForeignKey("dbo.MedicalRecords", "AdministeringDoctorId", "dbo.Contacts");
            DropIndex("dbo.MedicalRecords", new[] { "AdministeringDoctorId" });
            DropIndex("dbo.MedicalRecords", new[] { "MedicalRecordOwnerResidentId" });
            AlterColumn("dbo.MedicalRecords", "AdministeringDoctorId", c => c.Int());
            AlterColumn("dbo.MedicalRecords", "MedicalRecordOwnerResidentId", c => c.Int());
            CreateIndex("dbo.MedicalRecords", "AdministeringDoctorId");
            CreateIndex("dbo.MedicalRecords", "MedicalRecordOwnerResidentId");
            AddForeignKey("dbo.MedicalRecords", "MedicalRecordOwnerResidentId", "dbo.Residents", "ResidentId");
            AddForeignKey("dbo.MedicalRecords", "AdministeringDoctorId", "dbo.Contacts", "ContactId");
        }
    }
}
