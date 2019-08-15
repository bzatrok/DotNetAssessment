using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApp.Models;

namespace ProductApp.Utils
{
    public class ApiIntegration : IApiIntegration
    {
        private readonly string apiKey = "ExFNlAkCTKUdHusuItIv7oA4";

        public ApiIntegration()
        {

        }

        /// <inheritdoc/>
        public JObject GetProducts(string pageNumber)
        {
            using (var client = new HttpClient())
            {
                // Working query: https://api.bestbuy.com/v1/products?apiKey={apiKey}&page={pageNumber}&format=json

                string baseAddress = $"https://api.bestbuy.com/v1/products?apiKey={apiKey}&page={pageNumber}&format=json";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(baseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<JObject>(result);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public JObject GetProducts(string pageNumber, string keyword)
        {
            using (var client = new HttpClient())
            {
                // Working query: https://api.bestbuy.com/v1/products((search={keyword}))?apiKey=ExFNlAkCTKUdHusuItIv7oA4&page={pageNumber}&format=json

                string baseAddress = $"https://api.bestbuy.com/v1/products((search={keyword}))?apiKey=ExFNlAkCTKUdHusuItIv7oA4&page={pageNumber}&format=json";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(baseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<JObject>(result);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <inheritdoc/>
        public string GetProductPagesCount(JObject products)
        {
            return products["totalPages"].ToString();
        }

        /// <inheritdoc/>
        public List<ProductsModel> CastProducts(JObject products)
        {
            List<ProductsModel> productsList = new List<ProductsModel>();

            JArray productsArray = products["products"] as JArray;
            foreach (JObject product in productsArray)
            {
                productsList.Add(
                    new ProductsModel
                    {
                        SKU = product["sku"].ToString(),
                        Name = product["name"].ToString(),
                        Thumbnail = product["mediumImage"].ToString(),
                        RegularPrice = decimal.Parse(product["regularPrice"].ToString()),
                        SalePrice = decimal.Parse(product["salePrice"].ToString())
                    });
            }

            return productsList;
        }
    }
}