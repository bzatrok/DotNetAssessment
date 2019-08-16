using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApp.Models;

namespace ProductApp.Utils
{
    interface IApiIntegration
    {
        /// <summary>
        /// Gets all products from the api.
        /// </summary>
        /// <param name="pageNumber">The number of the currently displayed page.</param>
        /// <returns> A JSON object with api response. </returns>
        JObject GetProducts(string pageNumber);

        /// <summary>
        /// Gets all products from the api which match a keyword.
        /// </summary>
        /// <param name="pageNumber">The number of the currently displayed page.</param>
        /// <param name="keyword">The keyword to match products to.</param>
        /// <returns> A JSON object with api response. </returns>
        JObject GetProducts(string pageNumber, string keyword);

        /// <summary>
        /// Gets product data by id.
        /// </summary>
        /// <param name="id">The SKU value of the product.</param>
        /// <returns> A JSON object with api response. </returns>
        JObject GetProductById(string id);

        /// <summary>
        /// Gets the count of the pages with product results.
        /// </summary>
        /// <param name="products">A JSON object with api response.</param>
        /// <returns> A string with the value. </returns>
        string GetProductPagesCount(JObject products);

        /// <summary>
        /// Gets the related products IDs.
        /// </summary>
        /// <param name="product">A JSON object with api response.</param>
        /// <returns>A list of string values representing related product IDs. </returns>
        List<string> GetRelatedProductsID(JObject product);

        /// <summary>
        /// Casts products into a list of ProductsModel objects.
        /// </summary>
        /// <param name="products">A JSON object with api response.</param>
        /// <returns> List with ProductsModel objects. </returns>
        List<ProductsModel> CastProducts(JObject products);

        /// <summary>
        /// Casts product data into a product object.
        /// </summary>
        /// <param name="product">A JSON object with api response.</param>
        /// <returns> Product model object. </returns>
        SingleProductModel CastProduct(JObject product);
    }
}
