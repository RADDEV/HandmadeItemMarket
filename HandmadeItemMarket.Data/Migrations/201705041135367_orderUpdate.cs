namespace HandmadeItemMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "ApplicationUser_Id1");
            AddForeignKey("dbo.Orders", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.Orders", "ApplicationUser_Id1");
        }
    }
}
