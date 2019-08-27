using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment.BAL.Models
{
    public class ProductDetails:Product
    {
        public double? salePrice { get; set; }
        public string image { get; set; }       
        public int? customerReviewCount { get; set; }
        public double? customerReviewAverage { get; set; }
        public string longDescription { get; set; }
        public List<RelatedProducts> frequentlyPurchasedWith { get; set; }


    }

    public class RelatedProducts
        {
          public int sku { get; set; }
        }

}
