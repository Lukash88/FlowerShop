namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sieve.Models;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]

    public class ReservationsController : ApiControllerBase
    {
        public ReservationsController(IMediator mediator, ILogger<ReservationsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Reservations");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllReservations([FromQuery] SieveModel sieveModel)
        {
            GetReservationsRequest request = new GetReservationsRequest { SieveModel = sieveModel };

            return await this.HandleRequest<GetReservationsRequest, GetReservationsResponse>(request);
        }

        [HttpGet]
        [Route("{reservationId}")]
        public async Task<IActionResult> GetReservationById([FromRoute] int reservationId)
        {
            var request = new GetReservationByIdRequest()
            {
                ReservationId = reservationId
            };
            
            return await this.HandleRequest<GetReservationByIdRequest, GetReservationByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddReservation([FromBody] AddReservationRequest request) =>
            await this.HandleRequest<AddReservationRequest, AddReservationResponse>(request);

        [HttpDelete]
        [Route("{reservationId}")]
        public async Task<IActionResult> RemoveReservationById([FromRoute] int reservationId)
        {
            var request = new RemoveReservationRequest()
            {
                ReservationId = reservationId
            };
           
            return await this.HandleRequest<RemoveReservationRequest, RemoveReservationResponse>(request);
        }

        [HttpPut]
        [Route("{reservationId}")]
        public async Task<IActionResult> UpdateReservationById([FromRoute] int reservationId, [FromBody] UpdateReservationRequest request)
        {
            request.ReservationId = reservationId;
            
            return await this.HandleRequest<UpdateReservationRequest, UpdateReservationResponse>(request);
        }
    }
}