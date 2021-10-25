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

        [HttpGet]
        [Route("{flowerId}")]
        public async Task<IActionResult> GetFlowerById([FromRoute] int flowerId)
        {
            var request = new GetFlowerByIdRequest()
            {
                FlowerId = flowerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddFlower([FromBody] AddFlowerRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{flowerId}")]
        public async Task<IActionResult> RemoveFlowerById([FromRoute] int flowerId)
        {
            var request = new RemoveFlowerRequest()
            {
                FlowerId = flowerId           
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{flowerId}")]
        public async Task<IActionResult> UpdateFlowerById([FromRoute] int flowerId, [FromBody] UpdateFlowerRequest request)
        {
            var flower = new UpdateFlowerRequest()
            {
                FlowerId = flowerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
