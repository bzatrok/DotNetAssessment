using DotNetAssessment.Models.BestBuy;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAssessment.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public int PageNumber { get; set; }
        public int Pages { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public string PreviousClass { get { return PageNumber == 1 ? "disabled" : ""; } }
        public string NextClass { get { return PageNumber == Pages ? "disabled" : ""; } }

        public static ProductsViewModel MapBestBuyResponseToProductsViewModel(BestBuyResponse bestBuyResponse)
        {
            return new ProductsViewModel()
            {
                PageNumber = bestBuyResponse.currentPage,
                Pages = bestBuyResponse.totalPages,
                Products = bestBuyResponse.products.Select(p => ProductViewModel.MapProductToProductViewModel(p)).ToList()
            };
        }
    }
}