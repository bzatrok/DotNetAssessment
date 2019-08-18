using DotNetAssessment.Models.BestBuy;
using System.Linq;

namespace DotNetAssessment.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Sku { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        public string Name { get; set; }
        public string Price { get { return OnSale ? SalePrice : RegularPrice; } }
        public string RegularPrice { get; set; }
        public string SalePrice { get; set; }
        public bool OnSale { get; set; }
        public string PriceClass { get { return OnSale ? "onSale" : ""; } }
        public string AverageScore { get; set; }
        public string ReviewCount { get; set; }
        public string LongDescription { get; set; }
        public string[] RelatedSkus { get; set; }
        public string[] AccessoriesSkus { get; set; }
        public ProductsViewModel Accessories { get; set; }
        public ProductsViewModel Related { get; set; }
        public static ProductViewModel MapProductToProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Sku = product.sku,
                Thumbnail = product.thumbnailImage,
                Image = product.image,
                Name = product.name,
                RegularPrice = product.regularPrice,
                SalePrice = product.salePrice,
                OnSale = product.onSale,
                AverageScore = product.customerReviewAverage,
                ReviewCount = product.customerReviewCount,
                LongDescription = product.longDescription,
                RelatedSkus = product.relatedProducts?.Select(p => p.sku).ToArray(),
                AccessoriesSkus = product.accessories?.Select(p => p.sku).ToArray()
            };
        }
    }
}