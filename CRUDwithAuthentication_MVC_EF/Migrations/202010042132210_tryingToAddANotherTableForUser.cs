namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToAddANotherTableForUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
            
            DropForeignKey("dbo.PersonalInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PersonalInformations", new[] { "UserId" });
            DropTable("dbo.PersonalInformations");
        }
    }
}
