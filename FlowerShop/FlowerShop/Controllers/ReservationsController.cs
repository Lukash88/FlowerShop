namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]

    public class ReservationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllReservations([FromQuery] GetReservationsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{reservationId}")]
        public async Task<IActionResult> GetReservationById([FromRoute] int reservationId)
        {
            var request = new GetReservationByIdRequest()
            {
                ReservationId = reservationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddReservation([FromBody] AddReservationRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{reservationId}")]
        public async Task<IActionResult> RemoveReservationById([FromRoute] int reservationId)
        {
            var request = new RemoveReservationRequest()
            {
                ReservationId = reservationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{reservationId}")]
        public async Task<IActionResult> UpdateReservationById([FromRoute] int reservationId, [FromBody] UpdateReservationRequest request)
        {
            request.ReservationId = reservationId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
