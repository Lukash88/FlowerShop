namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class BouquetsController : ApiControllerBase
    {
        public BouquetsController(IMediator mediator, ILogger<BouquetsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Bouquets");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBouquets([FromQuery] GetBouquetsRequest request) => 
            await this.HandleRequest<GetBouquetsRequest, GetBouquetsResponse>(request);
        
        [HttpGet]
        [Route("{bouquetId}")]
        public async Task<IActionResult> GetBouquetById([FromRoute] int bouquetId)
        {
            var request = new GetBouquetByIdRequest()
            {
                BouquetId = bouquetId
            };

            return await this.HandleRequest<GetBouquetByIdRequest, GetBouquetByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBouquet([FromBody] AddBouquetRequest request) => 
            await this.HandleRequest<AddBouquetRequest, AddBouquetResponse>(request);                  

        [HttpDelete]
        [Route("{bouquetId}")]
        public async Task<IActionResult> RemoveBouquetById([FromRoute] int bouquetId)
        {
            var request = new RemoveBouquetRequest()
            {
                BouquetId = bouquetId
            };

            return await this.HandleRequest<RemoveBouquetRequest, RemoveBouquetResponse>(request);
        }

        [HttpPut]
        [Route("{bouquetId}")]
        public async Task<IActionResult> UpdateBouquetById([FromRoute] int bouquetId, [FromBody] UpdateBouquetRequest request)
        {
            request.BouquetId = bouquetId;

            return await this.HandleRequest<UpdateBouquetRequest, UpdateBouquetResponse>(request);        }
    }
}
