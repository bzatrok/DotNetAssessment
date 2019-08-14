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
        /// Gets all products from the api
        /// </summary>
        /// <returns> A JSON object with api response. </returns>
        JObject GetProducts();

        /// <summary>
        /// Gets the count of the pages with product results
        /// </summary>
        /// <param name="products">A JSON object with api response.</param>
        /// <returns> A string with the value. </returns>
        string GetProductPagesCount(JObject products);

        // <summary>
        /// Gets the current page number.
        /// </summary>
        /// <param name="products">A JSON object with api response.</param>
        /// <returns> A string with the value. </returns>
        string GetCurrentPageNumber(JObject products);

        /// <summary>
        /// Casts products into a list of ProductsModel objects.
        /// </summary>
        /// <param name="products">A JSON object with api response.</param>
        /// <returns> List with ProductsModel objects. </returns>
        List<ProductsModel> CastProducts(JObject products);
    }
}
