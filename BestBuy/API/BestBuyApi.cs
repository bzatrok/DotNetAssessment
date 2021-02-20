using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.API
{
    public class BestBuyApi
    {
        public static async Task<JToken> GetProductsWithName(string name, int page)
        {
            string url = $"https://api.bestbuy.com/v1/products(name=%22{name}*%22)?show=sku,name,salePrice,regularPrice,thumbnailImage&pageSize=7&page={page}&format=json&apiKey=OFb3ryAXys3WsmNU5EGd7qFh";

            var response = await CallWithUrl(url);

            return response;
        }

        public static async Task<JToken> GetProductDetailById(int id)
        {
            string url = $"https://api.bestbuy.com/v1/products(sku={id})?show=sku,name,image,regularPrice,salePrice,customerReviewCount,customerReviewAverage,shortDescription&format=json&apiKey=OFb3ryAXys3WsmNU5EGd7qFh";

            var response = await CallWithUrl(url);

            return response;
        }

        public static async Task<JToken> GetAlsoViewedProducts(int id)
        {
            string url = $"https://api.bestbuy.com/beta/products/{id}/alsoViewed?apiKey=OFb3ryAXys3WsmNU5EGd7qFh";

            var response = await CallWithUrl(url);

            return response;
        }

        private static async Task<JToken> CallWithUrl(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            try
            {
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                    return content;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
