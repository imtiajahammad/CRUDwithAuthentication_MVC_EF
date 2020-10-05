namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeUseridRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.Employee", new[] { "userid" });
            AlterColumn("dbo.Employee", "userid", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Employee", "userid");
            AddForeignKey("dbo.Employee", "userid", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.Employee", new[] { "userid" });
            AlterColumn("dbo.Employee", "userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employee", "userid");
            AddForeignKey("dbo.Employee", "userid", "dbo.AspNetUsers", "Id");
        }
    }
}
