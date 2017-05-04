using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HandmadeItemMarket.Models.EntityModels;
using HandmadeItemMarket.Models.ViewModels;

namespace HandmadeItemMarket.Services
{
    public class ProductsService:Service
    {
        public IEnumerable<ProductVM> RetrieveProductsFromCategory(string category)
        {
            IEnumerable<Product> products = this.Context.Products.Where(p=>p.Category==category);
            IEnumerable<ProductVM> vms = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVM>>(products);
            return vms;
        }
    }
}