using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.API.Controllers;

[Authorize]
public class DeliveryMethodsController : ApiControllerBase
{
    public DeliveryMethodsController(IMediator mediator, ILogger<DeliveryMethodsController> logger)
        : base(mediator, logger)
    {
        logger.LogInformation("We are in Delivery Methods");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllDeliveryMethods([FromQuery] SieveModel sieveModel)
    {
        var request = new GetDeliveryMethodsRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetDeliveryMethodsRequest, GetDeliveryMethodsResponse>(request);
    }

    [AllowAnonymous]
    [HttpGet("{methodId:int}")]
    public async Task<IActionResult> GetDeliveryMethodById([FromRoute] int methodId)
    {
        var request = new GetDeliveryMethodByIdRequest
        {
            MethodId = methodId
        };

        return await HandleRequest<GetDeliveryMethodByIdRequest, GetDeliveryMethodByIdResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddDeliveryMethod([FromBody] AddDeliveryMethodRequest request) =>
        await HandleRequest<AddDeliveryMethodRequest, AddDeliveryMethodResponse>(request);

    [HttpDelete("{methodId:int}")]
    public async Task<IActionResult> RemoveDeliveryMethodById([FromRoute] int methodId)
    {
        var request = new RemoveDeliveryMethodRequest
        {
            MethodId = methodId
        };

        return await HandleRequest<RemoveDeliveryMethodRequest, RemoveDeliveryMethodResponse>(request);
    }

    [HttpPut("{methodId:int}")]
    public async Task<IActionResult> UpdateDeliveryMethodById([FromRoute] int methodId,
        [FromBody] UpdateDeliveryMethodRequest request)
    {
        request.MethodId = methodId;

        return await HandleRequest<UpdateDeliveryMethodRequest, UpdateDeliveryMethodResponse>(request);
    }
}