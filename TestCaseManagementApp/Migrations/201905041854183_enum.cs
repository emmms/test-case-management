namespace TestCaseManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _enum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestCaseModels", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestCaseModels", "Priority", c => c.String(nullable: false));
        }
    }
}
