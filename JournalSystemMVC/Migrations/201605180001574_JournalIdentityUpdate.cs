namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JournalIdentityUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals");
            DropIndex("dbo.Journals", new[] { "JournalId" });
            DropPrimaryKey("dbo.Journals");
            AlterColumn("dbo.Journals", "JournalId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Journals", "JournalId");
            CreateIndex("dbo.Journals", "JournalId");
            AddForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals", "JournalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals");
            DropIndex("dbo.Journals", new[] { "JournalId" });
            DropPrimaryKey("dbo.Journals");
            AlterColumn("dbo.Journals", "JournalId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Journals", "JournalId");
            CreateIndex("dbo.Journals", "JournalId");
            AddForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals", "JournalId", cascadeDelete: true);
        }
    }
}
