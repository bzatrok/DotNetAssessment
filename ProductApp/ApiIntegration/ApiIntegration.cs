using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApp.Models;

namespace ApiIntegration
{
    public class ApiIntegration
    {
        private readonly string apiKey = "ExFNlAkCTKUdHusuItIv7oA4";

        public JObject GetProducts()
        {
            using (var client = new HttpClient())
            {
                // Working query: https://api.bestbuy.com/v1/products?apiKey={apiKey}&format=json

                string baseAddress = $"https://api.bestbuy.com/v1/products?apiKey={apiKey}&format=json";
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

        public List<ProductsModel> CastProducts(JObject products)
        {
            totalPages = products["totalPages"].ToString();

            List<ProductsModel> productsList = new List<ProductsModel>();

            JArray productsArray = products["products"] as JArray;
            foreach (JObject product in productsArray)
            {
                productsList.Add(
                    new ProductsModel
                    {
                        SKU = product["sku"].ToString(),
                        Name = product["name"].ToString(),
                        Thumbnail = product["images"][1]["href"].ToString(),
                        RegularPrice = decimal.Parse(product["regularPrice"].ToString()),
                        SalePrice = decimal.Parse(product["salePrice"].ToString())
                    });
            }

            return productsList;
        }
    }
}
