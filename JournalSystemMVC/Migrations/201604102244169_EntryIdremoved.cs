namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryIdremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals");
            DropIndex("dbo.JournalEntries", new[] { "JournalId" });
            RenameColumn(table: "dbo.JournalEntries", name: "JournalId", newName: "Journal_JournalId");
            AlterColumn("dbo.JournalEntries", "Journal_JournalId", c => c.Int());
            CreateIndex("dbo.JournalEntries", "Journal_JournalId");
            AddForeignKey("dbo.JournalEntries", "Journal_JournalId", "dbo.Journals", "JournalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalEntries", "Journal_JournalId", "dbo.Journals");
            DropIndex("dbo.JournalEntries", new[] { "Journal_JournalId" });
            AlterColumn("dbo.JournalEntries", "Journal_JournalId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.JournalEntries", name: "Journal_JournalId", newName: "JournalId");
            CreateIndex("dbo.JournalEntries", "JournalId");
            AddForeignKey("dbo.JournalEntries", "JournalId", "dbo.Journals", "JournalId", cascadeDelete: true);
        }
    }
}
