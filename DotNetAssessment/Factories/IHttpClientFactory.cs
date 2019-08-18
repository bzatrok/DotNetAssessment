using System.Net.Http;

namespace DotNetAssessment.Factories
{
    public interface IHttpClientFactory
    {
        HttpClient GetHttpClient();
    }
}