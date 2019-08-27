using Assigment.BAL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.BAL.Services.Products
{
    public class ProductService : IProductService
    {
        private string ApiKey = "&apiKey=ExFNlAkCTKUdHusuItIv7oA4";
        private string BaseUrl = "https://api.bestbuy.com/v1/";

        public async Task<ProductList> GetAllProducts(string Search ,int pageNum=1 )
        {
            string ShowProp = "show=thumbnailImage,name,regularPrice,sku&pageSize=20";
            string AllProductsUrl = BaseUrl+"products?format=json&";
            string baseSearchUrl = BaseUrl+"products(search=" + Search +")?format=json&";
            string url;
            if (string.IsNullOrEmpty(Search) || Search == "undefind")
                url = string.Format("{0}{1}", AllProductsUrl, ShowProp +"&page=" + pageNum + ApiKey);
            else
                url = string.Format("{0}{1}", baseSearchUrl, ShowProp + "&page=" + pageNum + ApiKey);

            using (var client = new HttpClient())
            {
                ProductList ProductList = new ProductList();
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false); 

                if (response.IsSuccessStatusCode)
                {
                    var jasonarray = response.Content.ReadAsStringAsync().Result;
                    var _object = JsonConvert.DeserializeObject<JObject>(jasonarray);
                    ProductList.Products = _object.Value<JArray>("products").ToObject<List<Product>>();
                    ProductList.totalPages = _object.Value<int>("totalPages");
                    ProductList.total = _object.Value<int>("total");

                    return ProductList;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<ProductDetails> GetProduct(int id)
        {
            string Url = BaseUrl+"products/"+id+ ".json?show=sku,name,salePrice,regularPrice,thumbnailImage,image,customerReviewCount,customerReviewAverage,shortDescription,longDescription,frequentlyPurchasedWith" + ApiKey;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(Url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jasonData = response.Content.ReadAsStringAsync().Result;
                    var Product = JsonConvert.DeserializeObject<ProductDetails>(jasonData);
                    return Product;
                }
                else
                {
                    return null;
                }
            }
        }

        public async  Task<List<Product>> GetRelatedProducts(List<RelatedProducts> ProductIds)
        {
            List<Product> RelatedProductList = new List<Product>();
            int count = 0;

            foreach (var Id in ProductIds)
            {
                count++;
                string Url = BaseUrl + "products/" + Id.sku + ".json?show=sku,name,thumbnailImage,regularPrice" + ApiKey;

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(Url).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var jasonData = response.Content.ReadAsStringAsync().Result;
                        var Product = JsonConvert.DeserializeObject<Product>(jasonData);
                        RelatedProductList.Add (Product);
                    }
                   
                }

                if (count == 3)
                    break;              
            }

                return RelatedProductList;



        }
    }
}

