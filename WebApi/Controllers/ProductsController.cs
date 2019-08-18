using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private readonly string _key = "ExFNlAkCTKUdHusuItIv7oA4";
        private readonly string _url = "https://api.bestbuy.com/v1/";
           
        private HttpClient Client;

        
        [HttpGet]
        public HttpResponseMessage Get([FromUri] string search, [FromUri] string page)
        {
            Client = CreateHttpClient();
            // Creating query 
            string query =$"products{search}?apiKey={_key}&page={page}&size=20&format=json";
            string taskResult = "";

            HttpResponseMessage response = Task.Run(async () => await Client.GetAsync(query)).Result;
            if (response.IsSuccessStatusCode)
            {
                taskResult = Task.Run(async () => await response.Content.ReadAsStringAsync()).Result;


            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(new
                {
                    StatusCode = 0,
                    Response = taskResult
                }, Configuration.Formatters.JsonFormatter)
            };


        }
        private string GetUrlQuery()
        {
            return "";
        }

        private HttpClient CreateHttpClient()
        {

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                //PreAuthenticate = true,
                //UseDefaultCredentials = false,
            };
            HttpClient client =
                new HttpClient(httpClientHandler) { BaseAddress = new Uri(_url) };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

    }
}
