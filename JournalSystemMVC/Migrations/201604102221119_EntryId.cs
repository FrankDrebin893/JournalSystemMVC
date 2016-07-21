namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalEntries", "Journal_JournalId", "dbo.Journals");
            DropIndex("dbo.JournalEntries", new[] { "Journal_JournalId" });
            RenameColumn(table: "dbo.JournalEntries", name: "Journal_JournalId", newName: "JournalId");
            AlterColumn("dbo.JournalEntries", "JournalId", c => c.Int(nullable: false));
            CreateIndex("dbo.JournalEntries", "JournalId");
            AddForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals", "JournalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals");
            DropIndex("dbo.JournalEntries", new[] { "JournalId" });
            AlterColumn("dbo.JournalEntries", "JournalId", c => c.Int());
            RenameColumn(table: "dbo.JournalEntries", name: "JournalId", newName: "Journal_JournalId");
            CreateIndex("dbo.JournalEntries", "Journal_JournalId");
            AddForeignKey("dbo.JournalEntries", "Journal_JournalId", "dbo.Journals", "JournalId");
        }
    }
}
