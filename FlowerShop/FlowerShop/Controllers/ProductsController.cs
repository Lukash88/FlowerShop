namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Products");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request) =>
            await this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);

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