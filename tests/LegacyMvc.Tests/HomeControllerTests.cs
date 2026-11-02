using System.Web.Mvc;
using LegacyMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacyMvc.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexReturnsTheConventionalView()
        {
            using (var controller = new HomeController())
            {
                var result = controller.Index() as ViewResult;

                Assert.IsNotNull(result);
                Assert.AreEqual(string.Empty, result.ViewName);
            }
        }

        [TestMethod]
        public void IndexProvidesTheWelcomeMessage()
        {
            using (var controller = new HomeController())
            {
                var result = controller.Index() as ViewResult;

                Assert.IsNotNull(result);
                Assert.AreEqual(
                    "ASP.NET MVC 5 on .NET Framework 4.8",
                    result.ViewData["Message"] as string);
            }
        }
    }
}
