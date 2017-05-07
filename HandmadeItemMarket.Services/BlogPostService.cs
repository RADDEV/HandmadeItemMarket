namespace HandmadeItemMarket.Services
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    public class BlogPostService:Service
    {
        public object GetLastPost(int id)
        {
            var lastPost = Context.BlogPosts.OrderByDescending(a => a.Id).FirstOrDefault();
            return lastPost;
        }
    }
}