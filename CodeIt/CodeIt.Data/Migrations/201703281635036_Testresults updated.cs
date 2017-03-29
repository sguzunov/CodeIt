namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Testresultsupdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false),
                    TrackId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId);

            CreateTable(
                "dbo.Challenges",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Title = c.String(nullable: false, maxLength: 50),
                    Language = c.Int(nullable: false),
                    TimeInMs = c.Double(nullable: false),
                    MemoryInKb = c.Int(nullable: false),
                    Description = c.String(nullable: false),
                    CategoryId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Title, unique: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.FileDecriptions",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ChallengeId = c.Guid(nullable: false),
                    FileName = c.String(nullable: false),
                    FileExtension = c.String(nullable: false),
                    FileSystemPath = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Challenges", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Tests",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Input = c.String(nullable: false),
                    Output = c.String(nullable: false),
                    ChallengeId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Challenges", t => t.ChallengeId, cascadeDelete: true)
                .Index(t => t.ChallengeId);

            CreateTable(
                "dbo.Tracks",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);

            CreateTable(
                "dbo.TrackLogoes",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TrackId = c.Guid(nullable: false),
                    FileName = c.String(nullable: false),
                    FileExtension = c.String(nullable: false),
                    FileSystemPath = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Submissions",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    SourceCode = c.String(nullable: false),
                    IsRun = c.Boolean(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    ChallengeId = c.Guid(nullable: false),
                    User_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Challenges", t => t.ChallengeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.ChallengeId)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.TestResults",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApiIdentifier_Identifier = c.Int(nullable: false),
                    IsEvaluated = c.Boolean(nullable: false),
                    IsPassed = c.Boolean(nullable: false),
                    TimeLimited = c.Boolean(nullable: false),
                    RuntimeException = c.String(),
                    CompileError = c.String(),
                    SubmissionId = c.Guid(nullable: false),
                    TestId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: false)
                .Index(t => t.SubmissionId)
                .Index(t => t.TestId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    FirstName = c.String(maxLength: 20),
                    LastName = c.String(maxLength: 20),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestResults", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.Submissions", "ChallengeId", "dbo.Challenges");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TrackLogoes", "Id", "dbo.Tracks");
            DropForeignKey("dbo.Categories", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Tests", "ChallengeId", "dbo.Challenges");
            DropForeignKey("dbo.FileDecriptions", "Id", "dbo.Challenges");
            DropForeignKey("dbo.Challenges", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TestResults", new[] { "TestId" });
            DropIndex("dbo.TestResults", new[] { "SubmissionId" });
            DropIndex("dbo.Submissions", new[] { "User_Id" });
            DropIndex("dbo.Submissions", new[] { "ChallengeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TrackLogoes", new[] { "Id" });
            DropIndex("dbo.Tracks", new[] { "Name" });
            DropIndex("dbo.Tests", new[] { "ChallengeId" });
            DropIndex("dbo.FileDecriptions", new[] { "Id" });
            DropIndex("dbo.Challenges", new[] { "CategoryId" });
            DropIndex("dbo.Challenges", new[] { "Title" });
            DropIndex("dbo.Categories", new[] { "TrackId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TestResults");
            DropTable("dbo.Submissions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TrackLogoes");
            DropTable("dbo.Tracks");
            DropTable("dbo.Tests");
            DropTable("dbo.FileDecriptions");
            DropTable("dbo.Challenges");
            DropTable("dbo.Categories");
        }
    }
}
