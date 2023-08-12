using System.Threading.Tasks;
using FlowerShop.ApplicationServices.API.Domain.OrderItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class OrderItemsController : ApiControllerBase
    {
        public OrderItemsController(IMediator mediator, ILogger<OrderItemsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Order Items");
        }

        //[AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrderItems([FromQuery] SieveModel sieveModel)
        {
            var request = new GetOrderItemsRequest
            {
                SieveModel = sieveModel
            };

            return await this.HandleRequest<GetOrderItemsRequest, GetOrderItemsResponse>(request);
        }

        //[AllowAnonymous]
        [HttpGet]
        [Route("{orderItemId}")]
        public async Task<IActionResult> GetOrderItemById([FromRoute] int orderItemId)
        {
            var request = new GetOrderItemByIdRequest()
            {
                OrderItemId = orderItemId
            };

            return await this.HandleRequest<GetOrderItemByIdRequest, GetOrderItemByIdResponse>(request);
        }

       // [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrderItem([FromBody] AddOrderItemRequest request) =>
            await this.HandleRequest<AddOrderItemRequest, AddOrderItemResponse>(request);

        [AllowAnonymous]
        [HttpDelete]
        [Route("{orderItemId}")]
        public async Task<IActionResult> RemoveOrderItemById([FromRoute] int orderItemId)
        {
            var request = new RemoveOrderItemRequest()
            {
                OrderItemId = orderItemId
            };

            return await this.HandleRequest<RemoveOrderItemRequest, RemoveOrderItemResponse>(request);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemId([FromRoute] int orderItemId, [FromBody] UpdateOrderItemRequest request)
        {
            request.OrderItemId = orderItemId;

            return await this.HandleRequest<UpdateOrderItemRequest, UpdateOrderItemResponse>(request);
        }
    }
}