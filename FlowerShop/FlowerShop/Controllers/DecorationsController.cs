namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class DecorationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DecorationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDecorations([FromQuery] GetDecorationsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{decorationId}")]
        public async Task<IActionResult> GetDecorationById([FromRoute] int decorationId)
        {
            var request = new GetDecorationByIdRequest()
            {
                DecorationId = decorationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddDecoration([FromBody] AddDecorationRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{decorationId}")]
        public async Task<IActionResult> RemoveDecorationById([FromRoute] int decorationId)
        {
            var request = new RemoveDecorationRequest()
            {
                DecorationId = decorationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{decorationId}")]
        public async Task<IActionResult> UpdateDecorationById([FromRoute] int decorationId, [FromBody] UpdateDecorationRequest request)
        {
            var decoration = new UpdateDecorationRequest
            {
                DecorationId = decorationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
