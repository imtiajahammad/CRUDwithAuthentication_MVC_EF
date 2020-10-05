namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherContext : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Employee");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        TaxRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
