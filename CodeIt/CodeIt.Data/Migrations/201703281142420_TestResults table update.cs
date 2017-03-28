namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestResultstableupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestResults", "TimeLimited", c => c.Boolean(nullable: false));
            AddColumn("dbo.TestResults", "RuntimeException", c => c.String());
            AddColumn("dbo.TestResults", "CompileError", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestResults", "CompileError");
            DropColumn("dbo.TestResults", "RuntimeException");
            DropColumn("dbo.TestResults", "TimeLimited");
        }
    }
}
