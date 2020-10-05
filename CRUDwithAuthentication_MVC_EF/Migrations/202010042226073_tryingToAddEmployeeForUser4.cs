namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToAddEmployeeForUser4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employee", new[] { "Id" });
            AddColumn("dbo.Employee", "userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employee", "userid");
            AddForeignKey("dbo.Employee", "userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.Employee", new[] { "userid" });
            DropColumn("dbo.Employee", "userid");
            CreateIndex("dbo.Employee", "Id");
            AddForeignKey("dbo.Employee", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
