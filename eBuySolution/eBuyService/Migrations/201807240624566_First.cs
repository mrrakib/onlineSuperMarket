namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryID = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(precision: 18, scale: 2),
                        Size = c.String(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        UnitOnOrder = c.Int(),
                        ProductAvailable = c.Boolean(),
                        ImageURL = c.String(),
                        AltText = c.String(),
                        AddBadge = c.Boolean(),
                        OfferTitle = c.String(),
                        OfferBadgeClass = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Picture1 = c.String(),
                        Picture2 = c.String(),
                        Picture3 = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        OrderDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderDetailsID)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PaymentID = c.Int(),
                        ShippingID = c.Int(),
                        Discount = c.Int(),
                        Taxes = c.Int(),
                        TotalAmount = c.Int(),
                        IsCompleted = c.Boolean(),
                        OrderDate = c.DateTime(),
                        DIspatched = c.Boolean(),
                        DispatchedDate = c.DateTime(),
                        Shipped = c.Boolean(),
                        ShippingDate = c.DateTime(),
                        Deliver = c.Boolean(),
                        DeliveryDate = c.DateTime(),
                        CancelOrder = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Payment", t => t.PaymentID)
                .ForeignKey("dbo.ShippingDetail", t => t.ShippingID)
                .Index(t => t.CustomerID)
                .Index(t => t.PaymentID)
                .Index(t => t.ShippingID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false),
                        Last_Name = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 450),
                        Password = c.String(),
                        Age = c.Int(),
                        Gender = c.String(),
                        DateofBirth = c.DateTime(),
                        Country = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Picture = c.String(),
                        LastLogin = c.DateTime(),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        ProductID = c.Int(),
                        Name = c.String(),
                        Email = c.String(),
                        Review1 = c.String(),
                        Rate = c.Int(),
                        DateTime = c.DateTime(),
                        isDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Wishlist",
                c => new
                    {
                        WishlistID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.WishlistID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CreditAmount = c.Decimal(precision: 18, scale: 2),
                        DebitAmount = c.Decimal(precision: 18, scale: 2),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        PaymentDateTime = c.DateTime(),
                        PaymentType_PayTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.PaymentType", t => t.PaymentType_PayTypeID)
                .Index(t => t.PaymentType_PayTypeID);
            
            CreateTable(
                "dbo.PaymentType",
                c => new
                    {
                        PayTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PayTypeID);
            
            CreateTable(
                "dbo.ShippingDetail",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.ShippingID);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        SubCategoryName = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Product", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "ShippingID", "dbo.ShippingDetail");
            DropForeignKey("dbo.Payment", "PaymentType_PayTypeID", "dbo.PaymentType");
            DropForeignKey("dbo.Order", "PaymentID", "dbo.Payment");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Wishlist", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Wishlist", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Review", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Review", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.SubCategory", new[] { "CategoryID" });
            DropIndex("dbo.Payment", new[] { "PaymentType_PayTypeID" });
            DropIndex("dbo.Wishlist", new[] { "ProductID" });
            DropIndex("dbo.Wishlist", new[] { "CustomerID" });
            DropIndex("dbo.Review", new[] { "ProductID" });
            DropIndex("dbo.Review", new[] { "CustomerID" });
            DropIndex("dbo.Customer", new[] { "UserName" });
            DropIndex("dbo.Order", new[] { "ShippingID" });
            DropIndex("dbo.Order", new[] { "PaymentID" });
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Product", new[] { "SubCategoryID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropTable("dbo.Supplier");
            DropTable("dbo.SubCategory");
            DropTable("dbo.ShippingDetail");
            DropTable("dbo.PaymentType");
            DropTable("dbo.Payment");
            DropTable("dbo.Wishlist");
            DropTable("dbo.Review");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
