using FlowerShop.ApplicationServices.API.Domain.Flower;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.Controllers;

[Authorize]
public class FlowersController : ApiControllerBase
{
    public FlowersController(IMediator mediator, ILogger<FlowersController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Flowers");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllFlowers([FromQuery] SieveModel sieveModel)
    {
        var request = new GetFlowersRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetFlowersRequest, GetFlowersResponse>(request);
    }

    [AllowAnonymous]
    [HttpGet("{flowerId:int}")]
    public async Task<IActionResult> GetFlowerById([FromRoute] int flowerId)
    {
        var request = new GetFlowerByIdRequest()
        {
            FlowerId = flowerId
        };
        return await HandleRequest<GetFlowerByIdRequest, GetFlowerByIdResponse>(request);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AddFlower([FromBody] AddFlowerRequest request) =>
        await HandleRequest<AddFlowerRequest, AddFlowerResponse>(request);

    [HttpDelete("{flowerId:int}")]
    public async Task<IActionResult> RemoveFlowerById([FromRoute] int flowerId)
    {
        var request = new RemoveFlowerRequest()
        {
            FlowerId = flowerId
        };
        return await HandleRequest<RemoveFlowerRequest, RemoveFlowerResponse>(request);
    }

    [HttpPut("{flowerId:int}")]
    public async Task<IActionResult> UpdateFlowerById([FromRoute] int flowerId, [FromBody] UpdateFlowerRequest request)
    {
        request.FlowerId = flowerId;
        return await HandleRequest<UpdateFlowerRequest, UpdateFlowerResponse>(request);
    }
}