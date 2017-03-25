namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModelstosupportuserssubmissions : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Challenges", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Challenges", new[] { "Title" });
        }
    }
}
