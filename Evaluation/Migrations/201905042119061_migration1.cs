namespace Evaluation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
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
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
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
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluation", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Evaluation", "StudentID", "dbo.Student");
            DropIndex("dbo.Evaluation", new[] { "StudentID" });
            DropIndex("dbo.Evaluation", new[] { "TeacherID" });
            DropTable("dbo.Users");
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.Evaluation");
        }
    }
}
