namespace CodeIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Modifytestresultstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestResults", "Test_Id", "dbo.Tests");
            DropIndex("dbo.TestResults", new[] { "Test_Id" });
            RenameColumn(table: "dbo.TestResults", name: "Test_Id", newName: "TestId");
            AlterColumn("dbo.TestResults", "TestId", c => c.Guid(nullable: false));
            CreateIndex("dbo.TestResults", "TestId");
            AddForeignKey("dbo.TestResults", "TestId", "dbo.Tests", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropIndex("dbo.TestResults", new[] { "TestId" });
            AlterColumn("dbo.TestResults", "TestId", c => c.Guid());
            RenameColumn(table: "dbo.TestResults", name: "TestId", newName: "Test_Id");
            CreateIndex("dbo.TestResults", "Test_Id");
            AddForeignKey("dbo.TestResults", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
