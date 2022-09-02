namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sieve.Models;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class FlowersController : ApiControllerBase
    {
        public FlowersController(IMediator mediator, ILogger<FlowersController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Flowers");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllFlowers([FromQuery] SieveModel sieveModel)
        {
            GetFlowersRequest request = new GetFlowersRequest { SieveModel = sieveModel };
            
            return await this.HandleRequest<GetFlowersRequest, GetFlowersResponse>(request);
        }

        [HttpGet]
        [Route("{flowerId}")]
        public async Task<IActionResult> GetFlowerById([FromRoute] int flowerId)
        {
            var request = new GetFlowerByIdRequest()
            {
                FlowerId = flowerId
            };
            return await this.HandleRequest<GetFlowerByIdRequest, GetFlowerByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddFlower([FromBody] AddFlowerRequest request) =>
            await this.HandleRequest<AddFlowerRequest, AddFlowerResponse>(request);

        [HttpDelete]
        [Route("{flowerId}")]
        public async Task<IActionResult> RemoveFlowerById([FromRoute] int flowerId)
        {
            var request = new RemoveFlowerRequest()
            {
                FlowerId = flowerId           
            };
            return await this.HandleRequest<RemoveFlowerRequest, RemoveFlowerResponse>(request);
        }

        [HttpPut]
        [Route("{flowerId}")]
        public async Task<IActionResult> UpdateFlowerById([FromRoute] int flowerId, [FromBody] UpdateFlowerRequest request)
        {
            request.FlowerId = flowerId;
            return await this.HandleRequest<UpdateFlowerRequest, UpdateFlowerResponse>(request);
        }
    }
}
