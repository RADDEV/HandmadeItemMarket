using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HandmadeItemMarket.Startup))]
namespace HandmadeItemMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
