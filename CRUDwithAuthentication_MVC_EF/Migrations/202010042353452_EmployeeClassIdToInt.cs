namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeClassIdToInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employee", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employee", "Id");
        }
    }
}
