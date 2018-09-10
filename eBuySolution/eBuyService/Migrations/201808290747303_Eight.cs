namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eight : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Order", new[] { "CustomerID" });
            RenameColumn(table: "dbo.Order", name: "CustomerID", newName: "Customer_CustomerID");
            RenameColumn(table: "dbo.Order", name: "PaymentID", newName: "Payment_PaymentID");
            RenameColumn(table: "dbo.Order", name: "ShippingID", newName: "ShippingDetail_ShippingID");
            RenameIndex(table: "dbo.Order", name: "IX_PaymentID", newName: "IX_Payment_PaymentID");
            RenameIndex(table: "dbo.Order", name: "IX_ShippingID", newName: "IX_ShippingDetail_ShippingID");
            DropPrimaryKey("dbo.OrderDetail");

            DropColumn("dbo.OrderDetail", "OrderDetailsID");


            AddColumn("dbo.OrderDetail", "OrderDetailId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.OrderDetail", "SalePrice", c => c.Decimal(storeType: "money"));
            AddColumn("dbo.OrderDetail", "SaleQuantity", c => c.Int());
            AddColumn("dbo.OrderDetail", "TotalSale", c => c.Decimal(storeType: "money"));
            AddColumn("dbo.OrderDetail", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Order", "GrandTotal", c => c.Decimal(storeType: "money"));
            AddColumn("dbo.Order", "GrandTotalItem", c => c.Int());
            AddColumn("dbo.Order", "CustomerName", c => c.String(maxLength: 50));
            AddColumn("dbo.Order", "CustomerAddress", c => c.String());
            AddColumn("dbo.Order", "CustomerPhone", c => c.String(maxLength: 20));
            AddColumn("dbo.Order", "CustomerEmail", c => c.String(maxLength: 40));
            AlterColumn("dbo.OrderDetail", "OrderId", c => c.Int());
            AlterColumn("dbo.OrderDetail", "ProductId", c => c.String());
            AlterColumn("dbo.Order", "Customer_CustomerID", c => c.Int());
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime(storeType: "date"));
            AddPrimaryKey("dbo.OrderDetail", "OrderDetailId");
            CreateIndex("dbo.OrderDetail", "OrderId");
            CreateIndex("dbo.OrderDetail", "Product_ProductID");
            CreateIndex("dbo.Order", "Customer_CustomerID");
            AddForeignKey("dbo.OrderDetail", "Product_ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order", "OrderId");
            AddForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer", "CustomerID");
            //DropColumn("dbo.OrderDetail", "OrderDetailsID");
            DropColumn("dbo.OrderDetail", "UnitPrice");
            DropColumn("dbo.OrderDetail", "Quantity");
            DropColumn("dbo.OrderDetail", "Discount");
            DropColumn("dbo.OrderDetail", "TotalAmount");
            DropColumn("dbo.OrderDetail", "OrderDate");
            DropColumn("dbo.Order", "Discount");
            DropColumn("dbo.Order", "Taxes");
            DropColumn("dbo.Order", "TotalAmount");
            DropColumn("dbo.Order", "IsCompleted");
            DropColumn("dbo.Order", "DIspatched");
            DropColumn("dbo.Order", "DispatchedDate");
            DropColumn("dbo.Order", "Shipped");
            DropColumn("dbo.Order", "ShippingDate");
            DropColumn("dbo.Order", "Deliver");
            DropColumn("dbo.Order", "DeliveryDate");
            DropColumn("dbo.Order", "CancelOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "CancelOrder", c => c.Boolean());
            AddColumn("dbo.Order", "DeliveryDate", c => c.DateTime());
            AddColumn("dbo.Order", "Deliver", c => c.Boolean());
            AddColumn("dbo.Order", "ShippingDate", c => c.DateTime());
            AddColumn("dbo.Order", "Shipped", c => c.Boolean());
            AddColumn("dbo.Order", "DispatchedDate", c => c.DateTime());
            AddColumn("dbo.Order", "DIspatched", c => c.Boolean());
            AddColumn("dbo.Order", "IsCompleted", c => c.Boolean());
            AddColumn("dbo.Order", "TotalAmount", c => c.Int());
            AddColumn("dbo.Order", "Taxes", c => c.Int());
            AddColumn("dbo.Order", "Discount", c => c.Int());
            AddColumn("dbo.OrderDetail", "OrderDate", c => c.DateTime());
            AddColumn("dbo.OrderDetail", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetail", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetail", "Quantity", c => c.Int());
            AddColumn("dbo.OrderDetail", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.OrderDetail", "OrderDetailsID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "Product_ProductID", "dbo.Product");
            DropIndex("dbo.Order", new[] { "Customer_CustomerID" });
            DropIndex("dbo.OrderDetail", new[] { "Product_ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropPrimaryKey("dbo.OrderDetail");
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime());
            AlterColumn("dbo.Order", "Customer_CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetail", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetail", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "CustomerEmail");
            DropColumn("dbo.Order", "CustomerPhone");
            DropColumn("dbo.Order", "CustomerAddress");
            DropColumn("dbo.Order", "CustomerName");
            DropColumn("dbo.Order", "GrandTotalItem");
            DropColumn("dbo.Order", "GrandTotal");
            DropColumn("dbo.OrderDetail", "Product_ProductID");
            DropColumn("dbo.OrderDetail", "TotalSale");
            DropColumn("dbo.OrderDetail", "SaleQuantity");
            DropColumn("dbo.OrderDetail", "SalePrice");
            DropColumn("dbo.OrderDetail", "OrderDetailId");
            AddPrimaryKey("dbo.OrderDetail", "OrderDetailsID");
            RenameIndex(table: "dbo.Order", name: "IX_ShippingDetail_ShippingID", newName: "IX_ShippingID");
            RenameIndex(table: "dbo.Order", name: "IX_Payment_PaymentID", newName: "IX_PaymentID");
            RenameColumn(table: "dbo.Order", name: "ShippingDetail_ShippingID", newName: "ShippingID");
            RenameColumn(table: "dbo.Order", name: "Payment_PaymentID", newName: "PaymentID");
            RenameColumn(table: "dbo.Order", name: "Customer_CustomerID", newName: "CustomerID");
            CreateIndex("dbo.Order", "CustomerID");
            CreateIndex("dbo.OrderDetail", "ProductID");
            CreateIndex("dbo.OrderDetail", "OrderID");
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
