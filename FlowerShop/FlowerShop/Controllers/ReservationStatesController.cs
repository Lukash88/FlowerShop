namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.ReservationState;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ReservationStatesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationStatesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllReservationStates([FromQuery] GetReservationStatesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{reservationStateId}")]
        public async Task<IActionResult> GetReservationStateById([FromRoute] int reservationStateId)
        {
            var request = new GetReservationStateByIdRequest()
            {
                ReservationStateId = reservationStateId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddReservationState([FromBody] AddReservationStateRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{reservationStateId}")]
        public async Task<IActionResult> RemoveReservationStateById([FromRoute] int reservationStateId)
        {
            var request = new RemoveReservationStateRequest()
            {
                ReservationStateId = reservationStateId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{reservationStateId}")]
        public async Task<IActionResult> UpdateReservationStateById([FromRoute] int reservationStateId, [FromBody] UpdateReservationStateRequest request)
        {
            request.ReservationStateId = reservationStateId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
