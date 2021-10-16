using FlowerShop.ApplicationServices.API.Domain.ReservationState;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
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

        //[HttpGet]
        //[Route("{reservationStateId}")]
        //public async Task<IActionResult> GetReservationStateById([FromRoute] GetReservationStatesRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
