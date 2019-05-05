namespace TestCaseManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestCaseModels",
                c => new
                    {
                        TestCaseID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Priority = c.String(nullable: false),
                        Description = c.String(maxLength: 500),
                        Prerequisites = c.String(maxLength: 500),
                        TestSetModel_TestSetID = c.Int(),
                    })
                .PrimaryKey(t => t.TestCaseID)
                .ForeignKey("dbo.TestSetModels", t => t.TestSetModel_TestSetID)
                .Index(t => t.TestSetModel_TestSetID);
            
            CreateTable(
                "dbo.TestSteps",
                c => new
                    {
                        TestStepID = c.Int(nullable: false, identity: true),
                        TestCaseID = c.Int(nullable: false),
                        StepNumber = c.Int(nullable: false),
                        Action = c.String(),
                        Input = c.String(),
                        ExpectedResult = c.String(),
                        TestCaseModel_TestCaseID = c.Int(),
                        TestCaseModel_TestCaseID1 = c.Int(),
                    })
                .PrimaryKey(t => t.TestStepID)
                .ForeignKey("dbo.TestCaseModels", t => t.TestCaseModel_TestCaseID)
                .ForeignKey("dbo.TestCaseModels", t => t.TestCaseModel_TestCaseID1)
                .Index(t => t.TestCaseModel_TestCaseID)
                .Index(t => t.TestCaseModel_TestCaseID1);
            
            CreateTable(
                "dbo.TestSetModels",
                c => new
                    {
                        TestSetID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.TestSetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCaseModels", "TestSetModel_TestSetID", "dbo.TestSetModels");
            DropForeignKey("dbo.TestSteps", "TestCaseModel_TestCaseID1", "dbo.TestCaseModels");
            DropForeignKey("dbo.TestSteps", "TestCaseModel_TestCaseID", "dbo.TestCaseModels");
            DropIndex("dbo.TestSteps", new[] { "TestCaseModel_TestCaseID1" });
            DropIndex("dbo.TestSteps", new[] { "TestCaseModel_TestCaseID" });
            DropIndex("dbo.TestCaseModels", new[] { "TestSetModel_TestSetID" });
            DropTable("dbo.TestSetModels");
            DropTable("dbo.TestSteps");
            DropTable("dbo.TestCaseModels");
        }
    }
}
