namespace HandmadeItemMarket.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Microsoft.Build.Tasks;
    using Models.EntityModels;

    public interface IHandmadeItemMarketContext : IDisposable
    {
        IDbSet<Product> Products { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<BlogPost> BlogPosts { get; set; }
        IDbSet<RegisteredUser> RegisteredUsers { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Order> Orders { get; set; }

        DbSet<T> Set<T>()
        where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
         where TEntity : class;

        int SaveChanges();

        DbContext DbContext { get; }
    }

}
