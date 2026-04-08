using FlowerShop.ApplicationServices.API.Domain.Order;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System.Security.Claims;

namespace FlowerShop.API.Controllers;

[Authorize]
public class OrdersController : ApiControllerBase
{
    public OrdersController(IMediator mediator, ILogger<OrdersController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Orders");
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] SieveModel sieveModel)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetOrdersForUserRequest
        {
            Email = email!,
            SieveModel = sieveModel
        };

        return await HandleRequest<GetOrdersForUserRequest, GetOrdersResponse>(request);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetOrderByIdForUserRequest
        {
            BuyerEmail = email!,
            OrderId = id
        };

        return await HandleRequest<GetOrderByIdForUserRequest, GetOrderByIdForUserResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.BuyerEmail = email;

        return await HandleRequest<AddOrderRequest, AddOrderResponse>(request);
    }
}