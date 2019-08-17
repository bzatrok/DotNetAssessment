using System.Collections.Generic;
using ProductApp.Models;

namespace ProductApp.ViewModels
{
    public class HomeViewModel
    {
        public List<ProductsModel> products { get; set; }
        public int pagesCount { get; set; }
        public int pageNumber { get; set; }
        public string keyword { get; set; }
    }
}