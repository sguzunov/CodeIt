namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usershasmanysubmissions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "User_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.Submissions", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "SubmissionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "SubmissionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Submissions", "User_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.Submissions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
