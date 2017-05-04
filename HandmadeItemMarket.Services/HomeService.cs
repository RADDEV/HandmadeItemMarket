using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HandmadeItemMarket.Models.EntityModels;
using HandmadeItemMarket.Models.ViewModels;

namespace HandmadeItemMarket.Services
{
    public class HomeService:Service
    {
        public IEnumerable<ProductVM> GetHighestRatedProducts()
        {
            IEnumerable<Product> products = this.Context.Products.OrderByDescending(a => a.Rating).Take(9);
            IEnumerable<ProductVM> vms = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductVM>>(products);
            return vms;
        }
    }
}