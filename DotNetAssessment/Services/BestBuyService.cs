using DotNetAssessment.Factories;
using DotNetAssessment.Models.BestBuy;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetAssessment.Services
{
    public class BestBuyService : IBestBuyService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private string baseUrl = ConfigurationManager.AppSettings["BestBuyApiBaseUrl"];
        private string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private string searchQueryFormat { get { return baseUrl + "products(search={0})?format=json&show=sku,name,regularPrice,salePrice,onSale,thumbnailImage&page={1}&apiKey=" + apiKey; } }
        private string productDetailQueryFormat { get { return baseUrl + "products(sku={0})?format=json&apiKey=" + apiKey; } }
        
        public BestBuyService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<BestBuyResponse> GetProductsBySkusAsync(string[] skus)
        {
            var skusQuery = FormatSkusForQuery(skus);
            var query = string.Format(productDetailQueryFormat, skusQuery);

            return await SendBestBuyRequest(query).ConfigureAwait(false);
        }

        public async Task<BestBuyResponse> ProductDetailsAsync(string sku)
        {
            var query = string.Format(productDetailQueryFormat, sku);

            return await SendBestBuyRequest(query).ConfigureAwait(false);

        }

        public async Task<BestBuyResponse> PerformProductSearchAsync(string searchText, int pageNumber)
        {
            var searchQuery = FormatSearchTextForQuery(searchText);
            var query = string.Format(searchQueryFormat, searchQuery, pageNumber);

            return await SendBestBuyRequest(query).ConfigureAwait(false);
        }

        private async Task<BestBuyResponse> SendBestBuyRequest(string query)
        {
            try
            {
                HttpClient httpClient = httpClientFactory.GetHttpClient();

                var httpResponse = await httpClient.GetAsync(query).ConfigureAwait(false);

                return await httpResponse.Content.ReadAsAsync<BestBuyResponse>().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string FormatSearchTextForQuery(string searchText)
        {
            return searchText.Replace(" ", "&search=");
        }

        private string FormatSkusForQuery(string[] skus)
        {
            return string.Join("|sku=", skus);
        }
    }
}