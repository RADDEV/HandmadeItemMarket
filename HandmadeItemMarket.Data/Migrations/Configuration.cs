using HandmadeItemMarket.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HandmadeItemMarket.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HandmadeItemMarket.Data.HandmadeItemMarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "HandmadeItemMarket.Data.HandmadeItemMarketContext";
        }

        protected override void Seed(HandmadeItemMarketContext context)
        {
            if (!context.Roles.Any(role => role.Name == "RegisteredUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("RegisteredUser");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "BlogAuthor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("BlogAuthor");
                manager.Create(role);
            }
            if (!context.Categories.Any())
            {
                Category c1 = new Category()
                {
                    Name = "Clothing and Accessories"
                };
                Category c2 = new Category()
                {
                    Name = "Jewelry"
                };
                Category c3 = new Category()
                {
                    Name = "Craft Supplies and Tools"
                };
                Category c4 = new Category()
                {
                    Name = "Weddings"
                };
                Category c5 = new Category()
                {
                    Name = "Entertainment"
                };
                Category c6 = new Category()
                {
                    Name = "Home and Living"
                };
                Category c7 = new Category()
                {
                    Name = "Kids and Baby"
                };
                Category c8 = new Category()
                {
                    Name = "Vintage"
                };
                context.Categories.Add(c1);
                context.Categories.Add(c2);
                context.Categories.Add(c3);
                context.Categories.Add(c4);
                context.Categories.Add(c5);
                context.Categories.Add(c6);
                context.Categories.Add(c7);
                context.Categories.Add(c8);

            }
        }
    }
}
