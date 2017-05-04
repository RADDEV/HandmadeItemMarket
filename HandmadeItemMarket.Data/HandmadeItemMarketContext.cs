using System.Runtime.Remoting.Messaging;
using HandmadeItemMarket.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using HandmadeItemMarket.Models;

namespace HandmadeItemMarket.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HandmadeItemMarketContext : IdentityDbContext<ApplicationUser>
    {
        public HandmadeItemMarketContext()
            : base("name=HandmadeItemMarket", throwIfV1Schema: false)
        {
        }

       
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<BlogPost> BlogPosts { get; set; }
        public IDbSet<RegisteredUser> RegisteredUsers { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Order> Orders { get; set; }


        public static HandmadeItemMarketContext Create()
        {
            return new HandmadeItemMarketContext();
        }
    }
}