using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApp.Models;

namespace ProductApp.Utils
{
    public class ApiIntegration : IApiIntegration
    {
        private string apiKey = "";

        public ApiIntegration()
        {
            apiKey = ConfigurationManager.AppSettings["ApiKey"];
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
                // Working query: https://api.bestbuy.com/v1/products((search={keyword}))?apiKey={apiKey}&page={pageNumber}&format=json

                string baseAddress = $"https://api.bestbuy.com/v1/products((search={keyword}))?apiKey={apiKey}&page={pageNumber}&format=json";
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
        public JObject GetProductById(string id)
        {
            using (var client = new HttpClient())
            {
                // Working query: https://api.bestbuy.com/v1/products(sku={id})?apiKey=ExFNlAkCTKUdHusuItIv7oA4&format=json
                // https://api.bestbuy.com/v1/products/{id}.json?apiKey=ExFNlAkCTKUdHusuItIv7oA4&format=json

                //string baseAddress = $"https://api.bestbuy.com/v1/products(sku={id})?apiKey=ExFNlAkCTKUdHusuItIv7oA4&format=json";
                string baseAddress = $"https://api.bestbuy.com/v1/products/{id}.json?apiKey=ExFNlAkCTKUdHusuItIv7oA4&format=json";
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
        public List<string> GetRelatedProductsID(JObject product)
        {
            List<string> productIDs = new List<string>();

            foreach (JObject productID in product["frequentlyPurchasedWith"] as JArray)
            {
                productIDs.Add(productID["sku"].ToString());
            }

            return productIDs;
        }

        /// <inheritdoc/>
        public List<ProductsModel> CastProducts(JObject products)
        {
            List<ProductsModel> productsList = new List<ProductsModel>();

            JArray productsArray = products["products"] as JArray;
            foreach (JObject product in productsArray)
            {
                string Thumbnail = product["mediumImage"].ToString();
                if(string.IsNullOrEmpty(Thumbnail))
                {
                    Thumbnail = product["thumbnailImage"].ToString();
                }

                productsList.Add(
                    new ProductsModel
                    {
                        SKU = product["sku"].ToString(),
                        Name = product["name"].ToString(),
                        Thumbnail = Thumbnail,
                        RegularPrice = decimal.Parse(product["regularPrice"].ToString()),
                        SalePrice = decimal.Parse(product["salePrice"].ToString())
                    });
            }

            return productsList;
        }

        /// <inheritdoc/>
        public SingleProductModel CastProduct(JObject product)
        {
            string reviewCount = product["customerReviewCount"].ToString();
            if(string.IsNullOrEmpty(reviewCount))
            {
                reviewCount = "0";
            }

            string averageScore = product["customerReviewAverage"].ToString();
            if(string.IsNullOrEmpty(averageScore))
            {
                averageScore = "0";
            }

            string Image = product["largeImage"].ToString();
            if (string.IsNullOrEmpty(Image))
            {
                Image = product["thumbnailImage"].ToString();
            }

            SingleProductModel castedProduct = new SingleProductModel
            {
                SKU = product["sku"].ToString(),
                Name = product["name"].ToString(),
                Image = Image,
                RegularPrice = decimal.Parse(product["regularPrice"].ToString()),
                SalePrice = decimal.Parse(product["salePrice"].ToString()),
                ReviewCount = int.Parse(reviewCount),
                AverageReviewScore = float.Parse(averageScore, CultureInfo.InvariantCulture.NumberFormat),
                Description = product["longDescription"].ToString()
            };

            return castedProduct;
        }
    }
}