namespace HandmadeItemMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePosted = c.DateTime(nullable: false),
                        Image = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        Rating = c.Int(nullable: false),
                        Poster_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Poster_Id)
                .Index(t => t.Poster_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Rating = c.Int(nullable: false),
                        DatePosted = c.DateTime(nullable: false),
                        Poster_Id = c.String(maxLength: 128),
                        Product_Id = c.Int(),
                        BlogPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Poster_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_Id)
                .Index(t => t.Poster_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.BlogPost_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        HomeTown = c.String(),
                        Neighbourhood = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Image = c.String(),
                        Buyer_Id = c.String(maxLength: 128),
                        RegisteredUser_Id = c.Int(),
                        RegisteredUser_Id1 = c.Int(),
                        RegisteredUser_Id2 = c.Int(),
                        Seller_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                        ApplicationUser_Id2 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Buyer_Id)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_Id)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_Id1)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_Id2)
                .ForeignKey("dbo.AspNetUsers", t => t.Seller_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id2)
                .Index(t => t.Buyer_Id)
                .Index(t => t.RegisteredUser_Id)
                .Index(t => t.RegisteredUser_Id1)
                .Index(t => t.RegisteredUser_Id2)
                .Index(t => t.Seller_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id2);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTown = c.String(),
                        Neighbourhood = c.String(),
                        IdenityUserId = c.String(maxLength: 128),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdenityUserId)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.IdenityUserId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "BlogPost_Id", "dbo.BlogPosts");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ApplicationUser_Id2", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Seller_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RegisteredUsers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "RegisteredUser_Id2", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Products", "RegisteredUser_Id1", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Products", "RegisteredUser_Id", "dbo.RegisteredUsers");
            DropForeignKey("dbo.RegisteredUsers", "IdenityUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Buyer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Poster_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BlogPosts", "Poster_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RegisteredUsers", new[] { "Product_Id" });
            DropIndex("dbo.RegisteredUsers", new[] { "IdenityUserId" });
            DropIndex("dbo.Products", new[] { "ApplicationUser_Id2" });
            DropIndex("dbo.Products", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Products", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Products", new[] { "Seller_Id" });
            DropIndex("dbo.Products", new[] { "RegisteredUser_Id2" });
            DropIndex("dbo.Products", new[] { "RegisteredUser_Id1" });
            DropIndex("dbo.Products", new[] { "RegisteredUser_Id" });
            DropIndex("dbo.Products", new[] { "Buyer_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "BlogPost_Id" });
            DropIndex("dbo.Comments", new[] { "Product_Id" });
            DropIndex("dbo.Comments", new[] { "Poster_Id" });
            DropIndex("dbo.BlogPosts", new[] { "Poster_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Products");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.BlogPosts");
        }
    }
}
