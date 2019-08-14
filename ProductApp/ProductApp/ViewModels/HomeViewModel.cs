using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductApp.Models;

namespace ProductApp.ViewModels
{
    public class HomeViewModel
    {
        public List<ProductsModel> products { get; set; }
        public int pagesCount { get; set; }
        public int pageNumber { get; set; }
    }
}