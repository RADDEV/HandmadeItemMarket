using AutoMapper;
using HandmadeItemMarket.Data;

namespace HandmadeItemMarket.Services
{
    public class Service
    {
        public Service()
        {
            this.Context = new HandmadeItemMarketContext();
        }

        protected HandmadeItemMarketContext Context { get; }
    }
}