namespace HandmadeItemMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "Buyer_Id" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderedOn = c.DateTime(nullable: false),
                        FullAddress = c.String(),
                        AditionalInfo = c.String(),
                        Buyer_Id = c.String(maxLength: 128),
                        Product_Id = c.Int(),
                        Seller_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Buyer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Seller_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Seller_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Products", "Buyer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Buyer_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Seller_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "Seller_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Buyer_Id" });
            DropTable("dbo.Orders");
            CreateIndex("dbo.Products", "Buyer_Id");
            AddForeignKey("dbo.Products", "Buyer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
