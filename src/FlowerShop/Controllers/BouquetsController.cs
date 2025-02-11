﻿using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.API.Controllers;

[Authorize]
public class BouquetsController : ApiControllerBase
{
    public BouquetsController(IMediator mediator, ILogger<BouquetsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Bouquets");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllBouquets([FromQuery] SieveModel sieveModel)
    {
        var request = new GetBouquetsRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetBouquetsRequest, GetBouquetsResponse>(request);
    }

    [AllowAnonymous]
    [HttpGet("{bouquetId:int}")]
    public async Task<IActionResult> GetBouquetById([FromRoute] int bouquetId)
    {
        var request = new GetBouquetByIdRequest()
        {
            BouquetId = bouquetId
        };

        return await HandleRequest<GetBouquetByIdRequest, GetBouquetByIdResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddBouquet([FromBody] AddBouquetRequest request) =>
        await HandleRequest<AddBouquetRequest, AddBouquetResponse>(request);

    [HttpDelete("{bouquetId:int}")]
    public async Task<IActionResult> RemoveBouquetById([FromRoute] int bouquetId)
    {
        var request = new RemoveBouquetRequest()
        {
            BouquetId = bouquetId
        };

        return await HandleRequest<RemoveBouquetRequest, RemoveBouquetResponse>(request);
    }

    [HttpPut("{bouquetId:int}")]
    public async Task<IActionResult> UpdateBouquetById([FromRoute] int bouquetId,
        [FromBody] UpdateBouquetRequest request)
    {
        request.BouquetId = bouquetId;

        return await HandleRequest<UpdateBouquetRequest, UpdateBouquetResponse>(request);
    }
}