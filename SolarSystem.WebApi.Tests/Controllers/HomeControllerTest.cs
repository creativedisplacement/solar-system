using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarSystem.WebApi.Controllers;
using System.Web.Mvc;

namespace SolarSystem.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
