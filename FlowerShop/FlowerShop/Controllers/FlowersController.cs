using FlowerShop.ApplicationServices.API.Domain.Flower;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowersController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlowersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllFlowers([FromQuery] GetFlowersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        //[HttpGet]
        //[Route("{flowerId}")]
        //public async Task<IActionResult> GetFlowerById([FromQuery] GetFlowersRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
