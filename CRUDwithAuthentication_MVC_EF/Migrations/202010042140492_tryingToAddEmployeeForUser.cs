namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToAddEmployeeForUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalInformations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PersonalInformations", new[] { "UserId" });
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        TaxRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            DropTable("dbo.PersonalInformations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.Employee", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employee", new[] { "Id" });
            DropTable("dbo.Employee");
            CreateIndex("dbo.PersonalInformations", "UserId");
            AddForeignKey("dbo.PersonalInformations", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
