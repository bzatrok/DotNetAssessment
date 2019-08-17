using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using ProductApp.Models;
using ProductApp.ViewModels;

namespace ProductApp.Controllers
{
    public class HomeController : Controller
    {
        private Utils.ApiIntegration api = new Utils.ApiIntegration();
        private string totalPages = "";
        private string currentPage = "1";
        private string searchKeyword = "";

        public ActionResult Index(string pageNumber, string keyword)
        {
            if (!string.IsNullOrEmpty(pageNumber))
            {
                currentPage = pageNumber;
            }

            JObject products = new JObject();

            if (string.IsNullOrEmpty(keyword))
            {
                products = api.GetProducts(currentPage);
            }
            else
            {
                searchKeyword = keyword;
                products = api.GetProducts(currentPage, searchKeyword);
            }

            if(products == null)
            {
                return RedirectToAction("Home", "Error");
            }

            totalPages = api.GetProductPagesCount(products);
            List<ProductsModel> productsList = api.CastProducts(products);

            HomeViewModel model = new HomeViewModel {
                products = productsList,
                pagesCount = int.Parse(totalPages),
                pageNumber = int.Parse(currentPage),
                keyword = searchKeyword
            };

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
    }
}
 