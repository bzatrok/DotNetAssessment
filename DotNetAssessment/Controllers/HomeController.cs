using DotNetAssessment.Services;
using DotNetAssessment.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DotNetAssessment.Controllers
{
    public class HomeController : Controller
    {
        private IBestBuyService bestBuyService;

        public HomeController(IBestBuyService bestBuyService)
        {
            this.bestBuyService = bestBuyService;
        }

        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("Search", new { searchText = StringResources.DEFAULT_SEARCH, page = 1 });
        }

        [HttpPost]
        public ActionResult PostSearch(string searchText)
        {
            return RedirectToAction("Search", new { searchText, page = 1 });
        }

        [Route("home/{searchText}/{page}", Name = "search")]
        public ActionResult Search(string searchText, int page)
        {
            try
            {
                var bestBuyResponse = bestBuyService.PerformProductSearchAsync(searchText, page);
                var model = ProductsViewModel.MapBestBuyResponseToProductsViewModel(bestBuyResponse.Result);
                model.Title = string.Format("{0}: {1}", StringResources.SEARCH_RESULT, searchText);

                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        [Route("product-details/{sku}", Name = "detail")]
        public ActionResult ProductDetail(string sku)
        {
            try
            {
                var bestBuyResponse = bestBuyService.ProductDetailsAsync(sku);
                var model = ProductViewModel.MapProductToProductViewModel(bestBuyResponse.Result.products.Single());
                if (model.RelatedSkus?.Count() > 0)
                    model.Related = ProductsViewModel.MapBestBuyResponseToProductsViewModel(
                        bestBuyService.GetProductsBySkusAsync(model.RelatedSkus).Result);
                if (model.AccessoriesSkus?.Count() > 0)
                    model.Accessories = ProductsViewModel.MapBestBuyResponseToProductsViewModel(
                        bestBuyService.GetProductsBySkusAsync(model.AccessoriesSkus).Result);
                model.Title = model.Name;

                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}