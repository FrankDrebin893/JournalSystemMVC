namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missingMigration2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Residents", "JournalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Residents", "JournalId", c => c.Int(nullable: false));
        }
    }
}
