using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using ProductApp.Models;

namespace ProductApp.Tests.Utils
{
    [TestClass]
    public class ApiIntegrationTest
    {
        /// <summary>
        /// Test product response from API.
        ///</summary>
        [TestMethod]
        public void TestGetProducts()
        {
            ProductApp.Utils.ApiIntegration api = new ProductApp.Utils.ApiIntegration();

            JObject products = api.GetProducts("1");

            Assert.IsNotNull(products);
            Assert.IsInstanceOfType(products, typeof(JObject));

            products = api.GetProducts("1", "ab");
            Assert.IsNotNull(products);
            Assert.IsInstanceOfType(products, typeof(JObject));
        }

        /// <summary>
        /// Test product by id response from API.
        ///</summary>
        [TestMethod]
        public void TestGetProduct()
        {
            ProductApp.Utils.ApiIntegration api = new ProductApp.Utils.ApiIntegration();

            JObject product = api.GetProductById("1000006");

            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(JObject));
        }

        /// <summary>
        /// Test product pages count.
        ///</summary>
        [TestMethod]
        public void TestGetProductPagesCount()
        {
            ProductApp.Utils.ApiIntegration api = new ProductApp.Utils.ApiIntegration();

            JObject products = api.GetProducts("1");
            string productsCount = api.GetProductPagesCount(products);

            Assert.IsNotNull(productsCount);
            Assert.IsInstanceOfType(productsCount, typeof(string));
        }

        /// <summary>
        /// Test retrieval of related product ids.
        ///</summary>
        [TestMethod]
        public void TestGetRelatedProductsIDs()
        {
            ProductApp.Utils.ApiIntegration api = new ProductApp.Utils.ApiIntegration();

            JObject product = api.GetProductById("9433419");
            List<string> productIDs = api.GetRelatedProductsID(product);

            Assert.IsNotNull(productIDs);
            Assert.IsInstanceOfType(productIDs, typeof(List<string>));
        }

        /// <summary>
        /// Test products json object casting to list of ProductsModel objects.
        ///</summary>
        [TestMethod]
        public void TestCastProducts()
        {
            ProductApp.Utils.ApiIntegration api = new ProductApp.Utils.ApiIntegration();

            JObject products = api.GetProducts("1");
            List<ProductsModel> productsList = api.CastProducts(products);

            Assert.IsNotNull(productsList);
            Assert.IsInstanceOfType(productsList, typeof(List<ProductsModel>));
        }

        /// <summary>
        /// Test product json object casting to a SingleProductModel object.
        ///</summary>
        [TestMethod]
        public void TestCastProduct()
        {
            ProductApp.Utils.ApiIntegration api = new ProductApp.Utils.ApiIntegration();

            JObject productData = api.GetProductById("1000006");
            SingleProductModel product = api.CastProduct(productData);

            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(SingleProductModel));
        }
    }
}
