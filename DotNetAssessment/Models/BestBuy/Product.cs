using Newtonsoft.Json;

namespace DotNetAssessment.Models.BestBuy
{
    public class Product : BaseProduct
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string name { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string regularPrice { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string salePrice { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool onSale { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string image { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string thumbnailImage { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string longDescription { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string customerReviewAverage { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string customerReviewCount { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public BaseProduct[] relatedProducts { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public BaseProduct[] accessories { get; set; }
    }
}