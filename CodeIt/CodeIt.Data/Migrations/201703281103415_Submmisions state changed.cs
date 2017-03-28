namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submmisionsstatechanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "IsRun", c => c.Boolean(nullable: false));
            AddColumn("dbo.TestResults", "IsPassed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestResults", "IsPassed");
            DropColumn("dbo.Submissions", "IsRun");
        }
    }
}
