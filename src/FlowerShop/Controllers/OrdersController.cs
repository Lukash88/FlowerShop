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

    [HttpGet("all")]
    public async Task<IActionResult> GetAllOrders([FromQuery] SieveModel sieveModel)
    {
        var request = new GetOrdersRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetOrdersRequest, GetOrdersResponse>(request);
    }

    [HttpGet("{orderId:int}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
    {
        var request = new GetOrderByIdRequest
        {
            OrderId = orderId
        };

        return await HandleRequest<GetOrderByIdRequest, GetOrderByIdResponse>(request);
    }

    [HttpGet("userOrders")]
    public async Task<IActionResult> GetOrdersForUser([FromQuery] SieveModel sieveModel)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetOrdersForUserRequest
        {
            Email = email!,
            SieveModel = sieveModel
        };

        return await HandleRequest<GetOrdersForUserRequest, GetOrdersResponse>(request);
    }

    [HttpGet("userOrders/{id:int}")]
    public async Task<IActionResult> GetOrderByIdForUser([FromRoute] int id)
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

    [HttpDelete("{orderId:int}")]
    public async Task<IActionResult> RemoveOrderById([FromRoute] int orderId)
    {
        var request = new RemoveOrderRequest
        {
            OrderId = orderId
        };

        return await HandleRequest<RemoveOrderRequest, RemoveOrderResponse>(request);
    }

    [HttpPut("{orderId:int}")]
    public async Task<IActionResult> UpdateOrderById([FromRoute] int orderId, [FromBody] UpdateOrderRequest request)
    {
        request.OrderId = orderId;

        return await HandleRequest<UpdateOrderRequest, UpdateOrderResponse>(request);
    }
}