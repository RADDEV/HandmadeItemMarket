namespace HandmadeItemMarket.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Build.Tasks;
    using Models.EntityModels;

    public class HandmadeItemMarketDataContext : IdentityDbContext<ApplicationUser>, IHandmadeItemMarketContext
    {
        public HandmadeItemMarketDataContext()
            : base("name=HandmadeItemMarket")
        {
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<BlogPost> BlogPosts { get; set; }
        public IDbSet<RegisteredUser> RegisteredUsers { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Order> Orders { get; set; }

        public DbContext DbContext => this;

        public static HandmadeItemMarketDataContext Create()
        {
            return new HandmadeItemMarketDataContext();
        }
        
    }
}