namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropColumn("dbo.Product", "SupplierID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "SupplierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "SupplierID");
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID", cascadeDelete: true);
        }
    }
}
