using FlowerShop.API.Controllers;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(IMediator mediator, ILogger<AdminController> logger) : ApiControllerBase(mediator, logger)
{
    [Authorize(Roles = "Admin, Manager")]
    [HttpGet("orders")]
    public async Task<IActionResult> GetAllOrders([FromQuery] SieveModel sieveModel)
    {
        logger.LogInformation("Admin: GetAllOrders called");
        var request = new GetOrdersRequest { SieveModel = sieveModel };

        return await HandleRequest<GetOrdersRequest, GetOrdersResponse>(request);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpGet("orders/{id:int}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        logger.LogInformation("Admin: GetOrderById called for ID: {OrderId}", id);
        var request = new GetOrderByIdRequest { Id = id };

        return await HandleRequest<GetOrderByIdRequest, GetOrderByIdResponse>(request);
    }

    [HttpDelete("orders/{id:int}")]
    public async Task<IActionResult> RemoveOrderById([FromRoute] int id)
    {
        logger.LogWarning("Admin: RemoveOrderById called for ID: {OrderId}", id);
        var request = new RemoveOrderRequest { Id = id };

        return await HandleRequest<RemoveOrderRequest, RemoveOrderResponse>(request);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPut("orders/{id:int}")]
    public async Task<IActionResult> UpdateOrderById([FromRoute] int id, [FromBody] UpdateOrderRequest request)
    {
        logger.LogInformation("Admin: UpdateOrderById called for ID: {OrderId}", id);
        request.Id = id;

        return await HandleRequest<UpdateOrderRequest, UpdateOrderResponse>(request);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPost("payments/refund/{orderId:int}")]
    public async Task<IActionResult> RefundPayment([FromRoute] int orderId)
    {
        logger.LogWarning("Admin: RefundPayment called for Order ID: {OrderId}", orderId);
        var request = new RefundPaymentForOrderRequest { Id = orderId };

        return await HandleRequest<RefundPaymentForOrderRequest, RefundPaymentForOrderResponse>(request);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers([FromQuery] SieveModel sieveModel)
    {
        logger.LogInformation("Admin: GetUsers called");
        var request = new GetUsersRequest() { SieveModel = sieveModel };

        return await HandleRequest<GetUsersRequest, GetUsersResponse>(request);
    }

    [HttpDelete("users/{email}")]
    public async Task<IActionResult> RemoveUserByEmail([FromRoute] string email)
    {
        logger.LogWarning("Admin: RemoveUserByEmail called for: {Email}", email);
        var request = new RemoveUserRequest() { Email = email };
        
        return await HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
    }
}