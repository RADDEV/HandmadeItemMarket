using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HandmadeItemMarket.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandmadeItemMarket.Test
{
    [TestClass]
    class HomeControllerTests
    {
        public void Index_ShouldReturnTop9Products()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            
            result.
        }
    }
}
