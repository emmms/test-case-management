namespace TestCaseManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestSteps", "TestCaseModel_TestCaseID", "dbo.TestCaseModels");
            DropForeignKey("dbo.TestSteps", "TestCaseModel_TestCaseID1", "dbo.TestCaseModels");
            DropIndex("dbo.TestSteps", new[] { "TestCaseModel_TestCaseID" });
            DropIndex("dbo.TestSteps", new[] { "TestCaseModel_TestCaseID1" });
            DropColumn("dbo.TestSteps", "TestCaseID");
            RenameColumn(table: "dbo.TestSteps", name: "TestCaseModel_TestCaseID1", newName: "TestCaseID");
            AlterColumn("dbo.TestSteps", "TestCaseID", c => c.Int(nullable: false));
            CreateIndex("dbo.TestSteps", "TestCaseID");
            AddForeignKey("dbo.TestSteps", "TestCaseID", "dbo.TestCaseModels", "TestCaseID", cascadeDelete: true);
            DropColumn("dbo.TestSteps", "TestCaseModel_TestCaseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestSteps", "TestCaseModel_TestCaseID", c => c.Int());
            DropForeignKey("dbo.TestSteps", "TestCaseID", "dbo.TestCaseModels");
            DropIndex("dbo.TestSteps", new[] { "TestCaseID" });
            AlterColumn("dbo.TestSteps", "TestCaseID", c => c.Int());
            RenameColumn(table: "dbo.TestSteps", name: "TestCaseID", newName: "TestCaseModel_TestCaseID1");
            AddColumn("dbo.TestSteps", "TestCaseID", c => c.Int(nullable: false));
            CreateIndex("dbo.TestSteps", "TestCaseModel_TestCaseID1");
            CreateIndex("dbo.TestSteps", "TestCaseModel_TestCaseID");
            AddForeignKey("dbo.TestSteps", "TestCaseModel_TestCaseID1", "dbo.TestCaseModels", "TestCaseID");
            AddForeignKey("dbo.TestSteps", "TestCaseModel_TestCaseID", "dbo.TestCaseModels", "TestCaseID");
        }
    }
}
