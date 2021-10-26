namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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

        [HttpGet]
        [Route("{bouquetId}")]
        public async Task<IActionResult> GetBouquetById([FromRoute] int bouquetId)
        {
            var request = new GetBouquetByIdRequest()
            {
                BouquetId = bouquetId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBouquet([FromBody] AddBouquetRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{bouquetId}")]
        public async Task<IActionResult> RemoveBouquetById([FromRoute] int bouquetId)
        {
            var request = new RemoveBouquetRequest()
            {
                BouquetId = bouquetId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{bouquetId}")]
        public async Task<IActionResult> UpdateBouquetById([FromRoute] int bouquetId, [FromBody] UpdateBouquetRequest request)
        {
            var flower = new UpdateBouquetRequest()
            {
                BouquetId = bouquetId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
