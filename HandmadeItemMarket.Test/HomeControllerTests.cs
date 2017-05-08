using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandmadeItemMarket.Test
{
    using System.Web.Mvc;
    using Controllers;
    using Services;

    [TestClass]
    public class HomeControllerTests
    {
        private readonly HomeController Controller;
        private readonly HomeService HomeService;
        public HomeControllerTests()
        {
            this.HomeService = new HomeService();
            this.Controller = new HomeController();
        }

        [TestMethod]
        public void HomeIndex_ShouldReturnItsDefaultView()
        {
            var result = Controller.Index() as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName));
        }
    }
}
