using FlowerShop.ApplicationServices.API.Domain.Decoration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.API.Controllers;

[Authorize]
public class DecorationsController : ApiControllerBase
{
    public DecorationsController(IMediator mediator, ILogger<DecorationsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Decorations");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllDecorations([FromQuery] SieveModel sieveModel)
    {
        var request = new GetDecorationsRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetDecorationsRequest, GetDecorationsResponse>(request);
    }

    [AllowAnonymous]
    [HttpGet("{decorationId:int}")]
    public async Task<IActionResult> GetDecorationById([FromRoute] int decorationId)
    {
        var request = new GetDecorationByIdRequest()
        {
            DecorationId = decorationId
        };

        return await HandleRequest<GetDecorationByIdRequest, GetDecorationByIdResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddDecoration([FromBody] AddDecorationRequest request) =>
        await HandleRequest<AddDecorationRequest, AddDecorationResponse>(request);

    [HttpDelete("{decorationId:int}")]
    public async Task<IActionResult> RemoveDecorationById([FromRoute] int decorationId)
    {
        var request = new RemoveDecorationRequest()
        {
            DecorationId = decorationId
        };

        return await HandleRequest<RemoveDecorationRequest, RemoveDecorationResponse>(request);
    }

    [HttpPut("{decorationId:int}")]
    public async Task<IActionResult> UpdateDecorationById([FromRoute] int decorationId,
        [FromBody] UpdateDecorationRequest request)
    {
        request.DecorationId = decorationId;

        return await HandleRequest<UpdateDecorationRequest, UpdateDecorationResponse>(request);
    }
}