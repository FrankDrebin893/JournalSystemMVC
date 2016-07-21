namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avatarPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Avatar", c => c.Binary());
            AddColumn("dbo.Residents", "Avatar", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Residents", "Avatar");
            DropColumn("dbo.Employees", "Avatar");
        }
    }
}
