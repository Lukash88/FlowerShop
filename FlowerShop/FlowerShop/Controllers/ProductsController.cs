using System.Threading.Tasks;
using FlowerShop.ApplicationServices.API.Domain.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Products");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] SieveModel sieveModel)
        {            
            var request = new GetProductsRequest
            {
                SieveModel = sieveModel
            };

            return await this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };

            return await this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request) =>
            await this.HandleRequest<AddProductRequest, AddProductResponse>(request);

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> RemoveProductById([FromRoute] int productId)
        {
            var request = new RemoveProductRequest()
            {
                ProductId = productId
            };

            return await this.HandleRequest<RemoveProductRequest, RemoveProductResponse>(request);
        }

        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProductById([FromRoute] int productId, [FromBody] UpdateProductRequest request)
        {
            request.ProductId = productId;

            return await this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }
    }
}