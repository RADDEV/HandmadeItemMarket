using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using HandmadeItemMarket.Models.EntityModels;
using HandmadeItemMarket.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace HandmadeItemMarket
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Product, ProductVM>();
                expression.CreateMap<Order, OrderVM>().ForMember(vm=>vm.ProductName, configutionExpression=> configutionExpression.MapFrom(a=>a.Product.Name));
            });
        }
    }
}
