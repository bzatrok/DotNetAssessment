namespace ProductApp.Models
{
    public class SingleProductModel
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ReviewCount { get; set; }
        public float AverageReviewScore { get; set; }
        public string Description { get; set; }
    }
}