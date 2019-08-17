using System.Collections.Generic;
using ProductApp.Models;

namespace ProductApp.ViewModels
{
    public class ProductViewModel
    {
        public SingleProductModel product { get; set; }
        public List<SingleProductModel> relatedProducts { get; set; }
    }
}