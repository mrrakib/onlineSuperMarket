namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ten : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Order", "Payment_PaymentID", "dbo.Payment");
            DropForeignKey("dbo.Order", "ShippingDetail_ShippingID", "dbo.ShippingDetail");
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Order", new[] { "Payment_PaymentID" });
            DropIndex("dbo.Order", new[] { "ShippingDetail_ShippingID" });
            DropTable("dbo.Order");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(storeType: "date"),
                        GrandTotal = c.Decimal(storeType: "money"),
                        GrandTotalItem = c.Int(),
                        CustomerName = c.String(maxLength: 50),
                        CustomerAddress = c.String(),
                        CustomerPhone = c.String(maxLength: 20),
                        CustomerEmail = c.String(maxLength: 40),
                        Customer_CustomerID = c.Int(),
                        Payment_PaymentID = c.Int(),
                        ShippingDetail_ShippingID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateIndex("dbo.Order", "ShippingDetail_ShippingID");
            CreateIndex("dbo.Order", "Payment_PaymentID");
            CreateIndex("dbo.Order", "Customer_CustomerID");
            CreateIndex("dbo.OrderDetail", "OrderId");
            AddForeignKey("dbo.Order", "ShippingDetail_ShippingID", "dbo.ShippingDetail", "ShippingID");
            AddForeignKey("dbo.Order", "Payment_PaymentID", "dbo.Payment", "PaymentID");
            AddForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer", "CustomerID");
            AddForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order", "OrderId");
        }
    }
}
