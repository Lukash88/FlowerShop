using FlowerShop.ApplicationServices.API.Domain.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.Controllers;

[Authorize]
public class ProductsController : ApiControllerBase
{
    public ProductsController(IMediator mediator, ILogger<ProductsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Products");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] SieveModel sieveModel)
    {
        var request = new GetProductsRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetProductsRequest, GetProductsResponse>(request);
    }

    [AllowAnonymous]
    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProductById([FromRoute] int productId)
    {
        var request = new GetProductByIdRequest()
        {
            ProductId = productId
        };

        return await HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request) =>
        await HandleRequest<AddProductRequest, AddProductResponse>(request);

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> RemoveProductById([FromRoute] int productId)
    {
        var request = new RemoveProductRequest()
        {
            ProductId = productId
        };

        return await HandleRequest<RemoveProductRequest, RemoveProductResponse>(request);
    }

    [HttpPut("{productId:int}")]
    public async Task<IActionResult> UpdateProductById([FromRoute] int productId,
        [FromBody] UpdateProductRequest request)
    {
        request.ProductId = productId;

        return await HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
    }
}