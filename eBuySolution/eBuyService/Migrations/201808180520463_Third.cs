namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wishlist", "ProductID", "dbo.Product");
            DropIndex("dbo.Wishlist", new[] { "ProductID" });
            DropColumn("dbo.Wishlist", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wishlist", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Wishlist", "ProductID");
            AddForeignKey("dbo.Wishlist", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
