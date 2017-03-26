namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedsubmissionstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SourceCode = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ChallengeId = c.Guid(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Challenges", t => t.ChallengeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ChallengeId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsPassed = c.Boolean(nullable: false),
                        SubmissionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .Index(t => t.SubmissionId);
            
            AddColumn("dbo.AspNetUsers", "SubmissionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestResults", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.Submissions", "ChallengeId", "dbo.Challenges");
            DropIndex("dbo.TestResults", new[] { "SubmissionId" });
            DropIndex("dbo.Submissions", new[] { "User_Id" });
            DropIndex("dbo.Submissions", new[] { "ChallengeId" });
            DropColumn("dbo.AspNetUsers", "SubmissionId");
            DropTable("dbo.TestResults");
            DropTable("dbo.Submissions");
        }
    }
}
