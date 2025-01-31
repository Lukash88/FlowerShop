using FlowerShop.ApplicationServices.API.Domain.Reservation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.API.Controllers;

[Authorize]
public class ReservationsController : ApiControllerBase
{
    public ReservationsController(IMediator mediator, ILogger<ReservationsController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Reservations");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReservations([FromQuery] SieveModel sieveModel)
    {
        var request = new GetReservationsRequest
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetReservationsRequest, GetReservationsResponse>(request);
    }

    [HttpGet("{reservationId:int}")]
    public async Task<IActionResult> GetReservationById([FromRoute] int reservationId)
    {
        var request = new GetReservationByIdRequest()
        {
            ReservationId = reservationId
        };

        return await HandleRequest<GetReservationByIdRequest, GetReservationByIdResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> AddReservation([FromBody] AddReservationRequest request) =>
        await HandleRequest<AddReservationRequest, AddReservationResponse>(request);

    [HttpDelete("{reservationId:int}")]
    public async Task<IActionResult> RemoveReservationById([FromRoute] int reservationId)
    {
        var request = new RemoveReservationRequest()
        {
            ReservationId = reservationId
        };

        return await HandleRequest<RemoveReservationRequest, RemoveReservationResponse>(request);
    }

    [HttpPut("{reservationId:int}")]
    public async Task<IActionResult> UpdateReservationById([FromRoute] int reservationId,
        [FromBody] UpdateReservationRequest request)
    {
        request.ReservationId = reservationId;

        return await HandleRequest<UpdateReservationRequest, UpdateReservationResponse>(request);
    }
}