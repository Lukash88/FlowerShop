using FlowerShop.ApplicationServices.API.Domain.Decoration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
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

        //[HttpGet]
        //[Route("{decorationId}")]
        //public async Task<IActionResult> GetDecorationById([FromRoute] GetDecorationsRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
