namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eleven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: true, identity: true),
                        OrderDate = c.DateTime(storeType: "date"),
                        GrandTotal = c.Decimal(storeType: "money"),
                        GrandTotalItem = c.Int(),
                        CustomerName = c.String(maxLength: 50),
                        CustomerAddress = c.String(),
                        CustomerPhone = c.String(maxLength: 20),
                        CustomerEmail = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateIndex("dbo.OrderDetail", "OrderId");
            AddForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropTable("dbo.Order");
        }
    }
}
