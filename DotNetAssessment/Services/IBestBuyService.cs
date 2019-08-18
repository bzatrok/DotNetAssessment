using DotNetAssessment.Models.BestBuy;
using System.Threading.Tasks;

namespace DotNetAssessment.Services
{
    public interface IBestBuyService
    {
        Task<BestBuyResponse> GetProductsBySkusAsync(string[] skus);
        Task<BestBuyResponse> ProductDetailsAsync(string sku);
        Task<BestBuyResponse> PerformProductSearchAsync(string searchText, int pageNumber);
    }
}