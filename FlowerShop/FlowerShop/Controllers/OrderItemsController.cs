using FlowerShop.ApplicationServices.API.Domain.OrderItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrderItemsController : ApiControllerBase
    {
        public OrderItemsController(IMediator mediator, ILogger<OrderItemsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Order Items");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrderItems([FromQuery] GetOrderItemsRequest request) =>
            await this.HandleRequest<GetOrderItemsRequest, GetOrderItemsResponse>(request);

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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrderItem([FromBody] AddOrderItemRequest request) =>
            await this.HandleRequest<AddOrderItemRequest, AddOrderItemResponse>(request);

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

        [HttpPut]
        [Route("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemById([FromRoute] int orderItemId, [FromBody] UpdateOrderItemRequest request)
        {
            request.OrderItemId = orderItemId;

            return await this.HandleRequest<UpdateOrderItemRequest, UpdateOrderItemResponse>(request);
        }
    }
}
