namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserEmail = c.String(nullable: false, maxLength: 30),
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserPassword = c.String(nullable: false, maxLength: 30),
                        UserRole = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.UserEmail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
        }
    }
}
