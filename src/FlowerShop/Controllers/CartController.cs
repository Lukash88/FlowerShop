using FlowerShop.ApplicationServices.API.Domain.Cart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.API.Controllers;

public class CartController : ApiControllerBase
{
    public CartController(IMediator mediator, ILogger<CartController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Cart Controller");
    }

    [HttpGet("{cartId}")]
    public async Task<IActionResult> GetCartById([FromRoute] string cartId)
    {
        var request = new GetCartByIdRequest
        {
            CartId = cartId
        };

        return await HandleRequest<GetCartByIdRequest, GetCartByIdResponse>(request);
    }

    [HttpPost("{cartId}")]
    public async Task<IActionResult> UpdateCart([FromRoute] string cartId,
        [FromBody] UpdateCartRequest request)
    {
        request ??= new UpdateCartRequest();
        request.Id = cartId;

        return await HandleRequest<UpdateCartRequest, UpdateCartResponse>(request);
    }

    [HttpDelete("{cartId}")]
    public async Task<IActionResult> DeleteCartAsync([FromRoute] string cartId)
    {
        var request = new RemoveCartRequest
        {
            CartId = cartId
        };

        return await HandleRequest<RemoveCartRequest, RemoveCartResponse>(request);
    }
}