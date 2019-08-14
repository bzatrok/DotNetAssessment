using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApp.Models;
using ProductApp.ViewModels;

namespace ProductApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiKey = "ExFNlAkCTKUdHusuItIv7oA4";
        private string totalPages = "";

        public ActionResult Index()
        {         
            JObject products = GetProducts();
            if(products == null)
            {
                return RedirectToAction("Home", "Error");
            }

            List<ProductsModel> productsList = CastProducts(products);


            HomeViewModel model = new HomeViewModel();

            return View(model);
        }

        public ActionResult NoProduct()
        {
            ViewBag.Message = "Product was not found, please go back to index page.";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "An error occured please contact the support team or try again later.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private JObject GetProducts()
        {
            using (var client = new HttpClient())
            {
                // Working query: https://api.bestbuy.com/v1/products?apiKey={apiKey}&format=json

                string baseAddress = $"https://api.bestbuy.com/v1/products?apiKey={apiKey}&format=json";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(baseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<JObject>(result);
                }
                else
                {
                    return null;
                }
            }
        }

        private List<ProductsModel> CastProducts(JObject products)
        {
            totalPages = products["totalPages"].ToString();

            List<ProductsModel> productsList = new List<ProductsModel>();

            JArray productsArray = products["products"] as JArray;
            foreach(JObject product in productsArray)
            {
                productsList.Add(
                    new ProductsModel
                    {
                        SKU = product["sku"].ToString(),
                        Name = product["name"].ToString(),
                        Thumbnail = product["images"][1]["href"].ToString(),
                        RegularPrice = decimal.Parse(product["regularPrice"].ToString()),
                        SalePrice = decimal.Parse(product["salePrice"].ToString())
                    });
            }

            return productsList;
        }
    }
}
 