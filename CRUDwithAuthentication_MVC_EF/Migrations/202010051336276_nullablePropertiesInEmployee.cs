namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablePropertiesInEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Dob", c => c.DateTime());
            AlterColumn("dbo.Employee", "Salary", c => c.Int());
            AlterColumn("dbo.Employee", "TaxRate", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "TaxRate", c => c.Single(nullable: false));
            AlterColumn("dbo.Employee", "Salary", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
