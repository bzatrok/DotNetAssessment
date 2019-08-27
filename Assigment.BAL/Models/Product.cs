using System;
using System.Collections.Generic;
using System.Text;

namespace Assigment.BAL.Models
{
    public class Product
    {
        public int sku { get; set; }
        public string name { get; set; }
        public double regularPrice { get; set; }
        public string thumbnailImage { get; set; }
    }

    public class ProductList
    {
        public List<Product> Products { get; set; }
        public int totalPages { get; set; }
        public int total { get; set; }

    }
}
