
using Assigment.BAL.Models;
using Assigment.BAL.Services.Products;
using AssigmentApp.BAL.Helper;
using System.Collections.Generic;
using System.Web.Http;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;


namespace AssigmentApp.Controllers
{

    public class ProductController : ApiController
    {
        public ApiResponse _dto = new ApiResponse();

        IProductService _IProductService;
        public ProductController(IProductService IProductService)
        {
            _IProductService = IProductService;
        }



        [HttpGet]
        public ApiResponse GetAllProductsAsync(string search, int pagenum)
        {
            var AllProducts = _IProductService.GetAllProducts(search, pagenum);

            if (AllProducts != null)
            {
                _dto = new ApiResponse
                {
                    Data = AllProducts.Result,
                    Status = 200,
                    Message = "Suscess"
                };
                return _dto;
            }
            else
            {
                _dto = new ApiResponse
                {
                    Data = AllProducts.Result,
                    Status = -1,
                    Message = "There Are Errors"
                };
                return _dto;
            }

        }


        [HttpGet]
        public ApiResponse GetProductDetails(int id)
        {
            var ProducrDetails = _IProductService.GetProduct(id);

            if (ProducrDetails != null)
            {
                _dto = new ApiResponse
                {
                    Data = ProducrDetails.Result,
                    Status = 200,
                    Message = "Suscess"
                };
                return _dto;
            }
            else
            {
                _dto = new ApiResponse
                {
                    Data = ProducrDetails.Result,
                    Status = -1,
                    Message = "There Are Errors"
                };
                return _dto;
            }
        }


        [HttpPost]
        public ApiResponse GetRelatedProducts([FromBody]  List<RelatedProducts> ProductIds)
        {
            var RelatedProducts = _IProductService.GetRelatedProducts(ProductIds);

            if (RelatedProducts != null)
            {
                _dto = new ApiResponse
                {
                    Data = RelatedProducts.Result,
                    Status = 200,
                    Message = "Suscess"
                };
                return _dto;
            }
            else
            {
                _dto = new ApiResponse
                {
                    Data = RelatedProducts.Result,
                    Status = -1,
                    Message = "There Are Errors"
                };
                return _dto;
            }

        }
    }
}

