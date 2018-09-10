namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "SupplierID", c => c.Int(nullable: false));
            AddColumn("dbo.Wishlist", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "SupplierID");
            CreateIndex("dbo.Wishlist", "ProductID");
            AddForeignKey("dbo.Wishlist", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Wishlist", "ProductID", "dbo.Product");
            DropIndex("dbo.Wishlist", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropColumn("dbo.Wishlist", "ProductID");
            DropColumn("dbo.Product", "SupplierID");
        }
    }
}
