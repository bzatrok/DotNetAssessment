using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductApp.Controllers;

namespace ProductApp.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ViewResult result = controller.Index("1001307") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
