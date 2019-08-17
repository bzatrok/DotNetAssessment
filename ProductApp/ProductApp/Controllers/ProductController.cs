using System.Collections.Generic;
using System.Linq;
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
            JObject productData = api.GetProductById(id);
            if (productData == null)
            {
                return RedirectToAction("Home", "Error");
            }

            SingleProductModel product = api.CastProduct(productData);

            List<string> relatedProductIDs = api.GetRelatedProductsID(productData);

            List<SingleProductModel> relatedProducts = new List<SingleProductModel>();
            if(relatedProductIDs.Any())
            {
                // Three related products should be enough.
                for(int i = 0; i < 3; i++)
                {
                    JObject relatedProductData = api.GetProductById(relatedProductIDs[i]);
                    SingleProductModel relatedProduct = api.CastProduct(relatedProductData);
                    relatedProducts.Add(relatedProduct);
                }
            }

            ProductViewModel model = new ProductViewModel
            {
                product = product,
                relatedProducts = relatedProducts
            };

            return View(model);
        }
    }
}