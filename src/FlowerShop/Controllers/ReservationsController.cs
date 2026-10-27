using System.Security.Claims;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.API.Controllers;

[Authorize]
public class ReservationsController(IMediator mediator, ILogger<ReservationsController> logger) : ApiControllerBase(mediator, logger)
{
[HttpGet]
public async Task<IActionResult> GetReservations([FromQuery] SieveModel sieveModel)
    {
        logger.LogInformation("User: GetReservations called");
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetReservationsForUserRequest
        {
            Email = email!,
            SieveModel = sieveModel
        };

        return await HandleRequest<GetReservationsForUserRequest, GetReservationsResponse>(request);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetReservationById([FromRoute] int id)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetReservationByIdForUserRequest()
        {
            Email = email!,
            Id = id
        };

        return await HandleRequest<GetReservationByIdForUserRequest, GetReservationByIdResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddReservation([FromBody] AddReservationRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.Email = email!;

        return await HandleRequest<AddReservationRequest, AddReservationResponse>(request);
    }

    [HttpPut("{id:int}/cancel")]
    public async Task<IActionResult> CancelReservationById([FromRoute] int id)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new CancelReservationByIdRequest()
        {
            Email = email!,
            Id = id
        };

        return await HandleRequest<CancelReservationByIdRequest, CancelReservationByIdResponse>(request);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateReservationById([FromRoute] int id,
        [FromBody] UpdateReservationForUserRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.Email = email!;
        request.Id = id;

        return await HandleRequest<UpdateReservationForUserRequest, UpdateReservationResponse>(request);
    }
}