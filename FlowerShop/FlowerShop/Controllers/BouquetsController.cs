using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BouquetsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BouquetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBouquets([FromQuery] GetBouquetsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        //[HttpGet]
        //[Route("{bouquetId}")]
        //public async Task<IActionResult> GetBouquetById([FromRoute] GetBouquetsRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
