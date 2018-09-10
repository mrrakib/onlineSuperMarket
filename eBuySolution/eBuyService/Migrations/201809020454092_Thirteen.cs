namespace eBuyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thirteen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Quantity");
        }
    }
}
