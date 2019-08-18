namespace DotNetAssessment.Models.BestBuy
{
    public class BestBuyResponse
    {
        public int from { get; set; }
        public int to { get; set; }
        public int total { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public string queryTime { get; set; }
        public string totalTime { get; set; }
        public bool partial { get; set; }
        public string canonicalUrl { get; set; }
        public Product[] products { get; set; }
    }
}