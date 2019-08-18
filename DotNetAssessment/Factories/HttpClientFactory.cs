using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DotNetAssessment.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly HttpClient httpClient;
        public HttpClientFactory()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(5);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient GetHttpClient() => httpClient;
    }
}