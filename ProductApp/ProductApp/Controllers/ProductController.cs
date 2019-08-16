using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using ProductApp.Models;
using ProductApp.ViewModels;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private Utils.ApiIntegration api = new Utils.ApiIntegration();

        public ActionResult Index(string id)
        {
            var validatedID = Server.HtmlEncode(id);

            JObject productData = api.GetProductById(id);
            if (productData == null)
            {
                return RedirectToAction("Home", "Error");
            }

            SingleProductModel product = api.CastProduct(productData);

            ProductViewModel model = new ProductViewModel
            {
                product = product
            };

            return View(model);
        }
    }
}