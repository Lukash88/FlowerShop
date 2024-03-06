using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class DeliveryMethodsController : ApiControllerBase
    {
        public DeliveryMethodsController(IMediator mediator, ILogger<DeliveryMethodsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Delivery Methods");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDeliveryMethods([FromQuery] SieveModel sieveModel)
        {
            var request = new GetDeliveryMethodsRequest
            {
                SieveModel = sieveModel
            };

            return await this.HandleRequest<GetDeliveryMethodsRequest, GetDeliveryMethodsResponse>(request);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{methodId}")]
        public async Task<IActionResult> GetDeliveryMethodById([FromRoute] int methodId)
        {
            var request = new GetDeliveryMethodByIdRequest()
            {
                MethodId = methodId
            };

            return await this.HandleRequest<GetDeliveryMethodByIdRequest, GetDeliveryMethodByIdResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddDeliveryMethod([FromBody] AddDeliveryMethodRequest request) =>
            await this.HandleRequest<AddDeliveryMethodRequest, AddDeliveryMethodResponse>(request);

        [HttpDelete]
        [Route("{methodId}")]
        public async Task<IActionResult> RemoveDeliveryMethodById([FromRoute] int methodId)
        {
            var request = new RemoveDeliveryMethodRequest()
            {
                MethodId = methodId
            };

            return await this.HandleRequest<RemoveDeliveryMethodRequest, RemoveDeliveryMethodResponse>(request);
        }
        [AllowAnonymous]
        [HttpPut]
        [Route("{methodId}")]
        public async Task<IActionResult> UpdateDeliveryMethodById([FromRoute] int methodId, [FromBody] UpdateDeliveryMethodRequest request)
        {
            request.MethodId = methodId;

            return await this.HandleRequest<UpdateDeliveryMethodRequest, UpdateDeliveryMethodResponse>(request);
        }
    }
}