namespace CRUDwithAuthentication_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleCrud3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RoleViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
