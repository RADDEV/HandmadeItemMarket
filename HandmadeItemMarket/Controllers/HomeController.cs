using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandmadeItemMarket.Attributes;
using HandmadeItemMarket.Models.ViewModels;
using HandmadeItemMarket.Services;

namespace HandmadeItemMarket.Controllers
{
    [CustomAuthorize(Roles = "RegisteredUser")]
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [AllowAnonymous]
        [Route("index")]
        [Route("~/")]
        public ActionResult Index()
        {
            IEnumerable<ProductVM> vms = this.service.GetHighestRatedProducts();
            return View(vms);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}