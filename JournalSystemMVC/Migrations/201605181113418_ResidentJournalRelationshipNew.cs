namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResidentJournalRelationshipNew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Journals", "JournalId", "dbo.Residents");
            DropIndex("dbo.Journals", new[] { "JournalId" });
            AddColumn("dbo.Residents", "JournalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Residents", "JournalId");
            AddForeignKey("dbo.Residents", "JournalId", "dbo.Journals", "JournalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Residents", "JournalId", "dbo.Journals");
            DropIndex("dbo.Residents", new[] { "JournalId" });
            DropColumn("dbo.Residents", "JournalId");
            CreateIndex("dbo.Journals", "JournalId");
            AddForeignKey("dbo.Journals", "JournalId", "dbo.Residents", "ResidentId");
        }
    }
}
