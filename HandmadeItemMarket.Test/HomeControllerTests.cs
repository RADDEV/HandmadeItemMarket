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
    class HomeControllerTests:BaseTest
    {
        [TestMethod]
        public void Index_ShouldReturnIndexViewName()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index",result.ViewName);
        }
    }
}
