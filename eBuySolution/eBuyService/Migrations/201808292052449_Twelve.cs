namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Twelve : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            AlterColumn("dbo.OrderDetail", "ProductID", c => c.Int());
            CreateIndex("dbo.OrderDetail", "ProductID");
            AddForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product", "ProductID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            AlterColumn("dbo.OrderDetail", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetail", "ProductID");
            AddForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
