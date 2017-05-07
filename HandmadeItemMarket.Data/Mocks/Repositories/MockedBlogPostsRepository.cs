namespace HandmadeItemMarket.Data.Mocks.Repositories
{
    using Data.Repositories;
    using DbSets;
    using Models.EntityModels;

    public class MockedBlogPostsRepository : DbRepository<BlogPost>
    {
        public MockedBlogPostsRepository(HandmadeItemMarketContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedBlogPostsDbSet();
        }

    }
}