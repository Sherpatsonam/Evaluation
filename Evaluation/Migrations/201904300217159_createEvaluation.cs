namespace Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEvaluation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        EffectiveTeaching = c.String(),
                        ProvidesFeedback = c.String(),
                        learningClimate = c.String(),
                        DemonstrateKnowlege = c.String(),
                        professionalism = c.String(),
                        overAllRanking = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Semester = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);

            CreateTable(
                "dbo.Teacher",
                c => new
                {
                    TeacherID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    CourseID = c.String(),

                    StudentID = c.Int(),
                })
                .PrimaryKey(t => t.TeacherID)
               .ForeignKey("dbo.Teacher", t => t.TeacherID)
               .ForeignKey("dbo.Student", t => t.StudentID)
               .Index(t => t.TeacherID)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluation", "StudentID", "dbo.Student");
            
            DropForeignKey("dbo.Evaluation", "TeacherID", "dbo.Teacher");
            
            DropIndex("dbo.Evaluation", new[] { "StudentID" });
            DropIndex("dbo.Evaluation", new[] { "TeacherID" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.Evaluation");
        }
    }
}
