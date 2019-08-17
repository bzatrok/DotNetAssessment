using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductApp.Controllers;

namespace ProductApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index("1", "") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
