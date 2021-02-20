using BestBuy.API;
using BestBuy.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetSeachByName([FromQuery(Name = "name")] string name, [FromQuery(Name = "page") ] int page)
        {
            var apiResponse = await BestBuyApi.GetProductsWithName(name, page);
            if(apiResponse is null)
            {
                return StatusCode(500);
            }

            int numberOfProducts = apiResponse.SelectToken("total").Value<int?>() ?? 0;
            if ( numberOfProducts <= 0)
            {
                return NotFound();
            }

            var products = apiResponse.SelectTokens("products[*]")
                .Select(product => new ShortProduct
                { 
                    Id = product["sku"].Value<int?>() ?? 0,
                    Name = product["name"].Value<string>() ?? "",
                    Price = product["salePrice"].Value<float?>() ?? 0,
                    ThumbnailImage = product["thumbnailImage"].Value<string>() ?? ""
                    
                }).ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailedProductById(int id)
        {
            var productResponse = await BestBuyApi.GetProductDetailById(id);
            if (productResponse is null)
            {
                return StatusCode(500);
            }

            int numberOfProducts = productResponse.SelectToken("total").Value<int?>() ?? 0;
            if (numberOfProducts <= 0)
            {
                return NotFound();
            }

            var alsoViewedResponse = await BestBuyApi.GetAlsoViewedProducts(id);

            List<ShortProduct> alsoViewedProducts = new List<ShortProduct>();
            var resultFromJToken = alsoViewedResponse.SelectToken("results");

            if (alsoViewedResponse != null && resultFromJToken.Count() > 0)
            {
                alsoViewedProducts = resultFromJToken.Select(result => new ShortProduct 
                {
                    Id = result["sku"].Value<int?>() ?? 0,
                    Name = result["names"]["title"].Value<string>() ?? "",
                    ThumbnailImage = result["images"]["standard"].Value<string>() ?? "",
                    Price = result["prices"]["current"].Value<float?>() ?? 0
                }).Take(3).ToList();                
            }

            var detailedProduct = new DetailedProduct
            {
                Id = productResponse.SelectToken("products[0].sku").Value<int?>() ?? 0,
                ImageUrl = productResponse.SelectToken("products[0].image").Value<string>() ?? "",
                Name = productResponse.SelectToken("products[0].name").Value<string>() ?? "",
                RegularPrice = productResponse.SelectToken("products[0].regularPrice").Value<float?>() ?? 0,
                SalePrice = productResponse.SelectToken("products[0].salePrice").Value<float?>() ?? 0,
                ReviewCount = productResponse.SelectToken("products[0].customerReviewCount").Value<int?>() ?? 0,
                ReviewAverage = productResponse.SelectToken("products[0].customerReviewAverage").Value<float?>() ?? 0,
                Description = productResponse.SelectToken("products[0].shortDescription").Value<string>() ?? "",
                AlsoViewed = alsoViewedProducts
            };

            return Ok(detailedProduct);
        }
    }
}
