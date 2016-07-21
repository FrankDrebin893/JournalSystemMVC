namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionnaireRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scales", "Questionnaire_QuestionnaireId", "dbo.Questionnaires");
            DropIndex("dbo.Scales", new[] { "Questionnaire_QuestionnaireId" });
            RenameColumn(table: "dbo.Scales", name: "Questionnaire_QuestionnaireId", newName: "QuestionnaireId");
            AddColumn("dbo.Questionnaires", "ResidentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Scales", "QuestionnaireId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questionnaires", "ResidentId");
            CreateIndex("dbo.Scales", "QuestionnaireId");
            AddForeignKey("dbo.Questionnaires", "ResidentId", "dbo.Residents", "ResidentId", cascadeDelete: false);
            AddForeignKey("dbo.Scales", "QuestionnaireId", "dbo.Questionnaires", "QuestionnaireId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scales", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Questionnaires", "ResidentId", "dbo.Residents");
            DropIndex("dbo.Scales", new[] { "QuestionnaireId" });
            DropIndex("dbo.Questionnaires", new[] { "ResidentId" });
            AlterColumn("dbo.Scales", "QuestionnaireId", c => c.Int());
            DropColumn("dbo.Questionnaires", "ResidentId");
            RenameColumn(table: "dbo.Scales", name: "QuestionnaireId", newName: "Questionnaire_QuestionnaireId");
            CreateIndex("dbo.Scales", "Questionnaire_QuestionnaireId");
            AddForeignKey("dbo.Scales", "Questionnaire_QuestionnaireId", "dbo.Questionnaires", "QuestionnaireId");
        }
    }
}
