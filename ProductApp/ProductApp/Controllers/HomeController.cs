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
        private Utils.ApiIntegration api = new Utils.ApiIntegration();
        private string totalPages = "";

        public ActionResult Index()
        {         
            JObject products = api.GetProducts();
            if(products == null)
            {
                return RedirectToAction("Home", "Error");
            }

            totalPages = api.GetProductPagesCount(products);
            List<ProductsModel> productsList = api.CastProducts(products);

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
    }
}
 