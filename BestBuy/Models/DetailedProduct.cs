using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.Models
{
    public class DetailedProduct
    {
        public int Id { set; get; }

        public string ImageUrl { set; get; }

        public string Name { set; get; }

        public float RegularPrice { set; get; }

        public float SalePrice { set; get; }

        public int ReviewCount { set; get; }

        public float ReviewAverage { set; get; }

        public string Description { set; get; }

        public List<ShortProduct> AlsoViewed { set; get; }
    }
}
