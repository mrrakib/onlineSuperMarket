namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Customer_CustomerID");
            DropIndex("dbo.Order", new[] { "IX_Payment_PaymentID" });
            DropIndex("dbo.Order", new[] { "IX_ShippingDetail_ShippingID" });
            DropColumn("dbo.Order", "Payment_PaymentID");
            DropColumn("dbo.Order", "ShippingDetail_ShippingID");
        }
    }
}
