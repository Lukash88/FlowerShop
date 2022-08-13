namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sieve.Models;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class DecorationsController : ApiControllerBase
    {
        public DecorationsController(IMediator mediator, ILogger<DecorationsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Decorations");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDecorations([FromQuery] SieveModel sieveModel)
        {
            GetDecorationsRequest request = new GetDecorationsRequest { SieveModel = sieveModel };

           return await this.HandleRequest<GetDecorationsRequest, GetDecorationsResponse>(request);
        }

        [HttpGet]
        [Route("{decorationId}")]
        public async Task<IActionResult> GetDecorationById([FromRoute] int decorationId)
        {
            var request = new GetDecorationByIdRequest()
            {
                DecorationId = decorationId
            };

            return await this.HandleRequest<GetDecorationByIdRequest, GetDecorationByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddDecoration([FromBody] AddDecorationRequest request) =>
            await this.HandleRequest<AddDecorationRequest, AddDecorationResponse>(request);

        [HttpDelete]
        [Route("{decorationId}")]
        public async Task<IActionResult> RemoveDecorationById([FromRoute] int decorationId)
        {
            var request = new RemoveDecorationRequest()
            {
                DecorationId = decorationId
            };

            return await this.HandleRequest<RemoveDecorationRequest, RemoveDecorationResponse>(request);
        }

        [HttpPut]
        [Route("{decorationId}")]
        public async Task<IActionResult> UpdateDecorationById([FromRoute] int decorationId, [FromBody] UpdateDecorationRequest request)
        {
            request.DecorationId = decorationId;

            return await this.HandleRequest<UpdateDecorationRequest, UpdateDecorationResponse>(request);
        }
    }
}