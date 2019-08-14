﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class ProductsModel
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}