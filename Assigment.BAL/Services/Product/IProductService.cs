using Assigment.BAL.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.BAL.Services.Products
{
   public interface IProductService
    {
        Task<ProductList> GetAllProducts( string Search, int pageNum);
        Task<ProductDetails> GetProduct(int id);

        Task<List<Product>> GetRelatedProducts(List<RelatedProducts> ProductIds);

    }
}
