using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandmadeItemMarket.Data.Mocks
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Contracts;
    using DbSets;
    using Microsoft.Build.Tasks;
    using Models.EntityModels;

    public class MockedHandmadeItemMarketContext: DbContext,IHandmadeItemMarketContext
    {
        public MockedHandmadeItemMarketContext()
        {
            this.Products = new MockedProductsDbSet();
            this.Comments = new MockedCommentsDbSet();
            this.BlogPosts = new MockedBlogPostsDbSet();
            this.RegisteredUsers = new MockedDbSet<RegisteredUser>();
            this.Categories = new MockedCategoriesDbSet();
            this.Orders = new MockedOrdersDbSet();
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<BlogPost> BlogPosts { get; set; }
        public IDbSet<RegisteredUser> RegisteredUsers { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public DbSet<T> Set<T>() where T : class
        {
            return new MockedDbSet<T>();
        }

        // TODO: Implement this
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public DbContext DbContext => new MockedHandmadeItemMarketContext();

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}
