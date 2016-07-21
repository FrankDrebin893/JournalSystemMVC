namespace JournalSystemMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionFormTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questionnaires", "AuthorId", "dbo.Employees");
            DropForeignKey("dbo.Scales", "QuestionnaireId", "dbo.Questionnaires");
            DropForeignKey("dbo.Questionnaires", "ResidentId", "dbo.Residents");
            DropIndex("dbo.Questionnaires", new[] { "AuthorId" });
            DropIndex("dbo.Questionnaires", new[] { "ResidentId" });
            DropIndex("dbo.Scales", new[] { "QuestionnaireId" });
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ResidentId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        ResponseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: false)
                .ForeignKey("dbo.Residents", t => t.ResidentId, cascadeDelete: false)
                .Index(t => t.QuestionId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ResidentId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionFormId = c.Int(nullable: false),
                        QuestionText = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionForms", t => t.QuestionFormId, cascadeDelete: true)
                .Index(t => t.QuestionFormId);
            
            CreateTable(
                "dbo.QuestionForms",
                c => new
                    {
                        QuestionnaireId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.QuestionnaireId);
            
            DropTable("dbo.Questionnaires");
            DropTable("dbo.Scales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Scales",
                c => new
                    {
                        ScaleId = c.Int(nullable: false, identity: true),
                        QuestionnaireId = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 30),
                        Score = c.Int(),
                    })
                .PrimaryKey(t => t.ScaleId);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        QuestionnaireId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        ResidentId = c.Int(nullable: false),
                        QuestionnaireName = c.String(nullable: false),
                        Comment = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionnaireId);
            
            DropForeignKey("dbo.Answers", "ResidentId", "dbo.Residents");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestionFormId", "dbo.QuestionForms");
            DropForeignKey("dbo.Answers", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Questions", new[] { "QuestionFormId" });
            DropIndex("dbo.Answers", new[] { "ResidentId" });
            DropIndex("dbo.Answers", new[] { "EmployeeId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.QuestionForms");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            CreateIndex("dbo.Scales", "QuestionnaireId");
            CreateIndex("dbo.Questionnaires", "ResidentId");
            CreateIndex("dbo.Questionnaires", "AuthorId");
            AddForeignKey("dbo.Questionnaires", "ResidentId", "dbo.Residents", "ResidentId", cascadeDelete: true);
            AddForeignKey("dbo.Scales", "QuestionnaireId", "dbo.Questionnaires", "QuestionnaireId", cascadeDelete: true);
            AddForeignKey("dbo.Questionnaires", "AuthorId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
