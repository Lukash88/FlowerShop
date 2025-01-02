using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class DeliveryMethodsController : ApiControllerBase
    {
        public DeliveryMethodsController(IMediator mediator, ILogger<DeliveryMethodsController> logger) 
            : base(mediator, logger)
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

            return await HandleRequest<GetDeliveryMethodsRequest, GetDeliveryMethodsResponse>(request);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{methodId}")]
        public async Task<IActionResult> GetDeliveryMethodById([FromRoute] int methodId)
        {
            var request = new GetDeliveryMethodByIdRequest
            {
                MethodId = methodId
            };

            return await HandleRequest<GetDeliveryMethodByIdRequest, GetDeliveryMethodByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddDeliveryMethod([FromBody] AddDeliveryMethodRequest request) =>
            await HandleRequest<AddDeliveryMethodRequest, AddDeliveryMethodResponse>(request);

        [HttpDelete]
        [Route("{methodId}")]
        public async Task<IActionResult> RemoveDeliveryMethodById([FromRoute] int methodId)
        {
            var request = new RemoveDeliveryMethodRequest
            {
                MethodId = methodId
            };

            return await HandleRequest<RemoveDeliveryMethodRequest, RemoveDeliveryMethodResponse>(request);
        }

        [HttpPut]
        [Route("{methodId}")]
        public async Task<IActionResult> UpdateDeliveryMethodById([FromRoute] int methodId,
            [FromBody] UpdateDeliveryMethodRequest request)
        {
            request.MethodId = methodId;

            return await HandleRequest<UpdateDeliveryMethodRequest, UpdateDeliveryMethodResponse>(request);
        }
    }
}