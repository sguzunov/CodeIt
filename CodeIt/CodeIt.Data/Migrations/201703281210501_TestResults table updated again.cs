namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestResultstableupdatedagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Challenges", "TimeInMs", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Challenges", "TimeInMs", c => c.Int(nullable: false));
        }
    }
}
