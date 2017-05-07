namespace HandmadeItemMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kur1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "HomeTown", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Neighbourhood", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "FullAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.RegisteredUsers", "HomeTown", c => c.String(nullable: false));
            AlterColumn("dbo.RegisteredUsers", "Neighbourhood", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisteredUsers", "Neighbourhood", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "HomeTown", c => c.String());
            AlterColumn("dbo.Products", "Category", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Orders", "FullAddress", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Neighbourhood", c => c.String());
            AlterColumn("dbo.AspNetUsers", "HomeTown", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
            AlterColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.BlogPosts", "Content", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
        }
    }
}
