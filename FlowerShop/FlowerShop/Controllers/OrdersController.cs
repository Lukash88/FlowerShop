using FlowerShop.ApplicationServices.API.Domain.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetOrdersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var request = new GetOrderByIdRequest()
            {
                OrderId = orderId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> RemoveOrderById([FromRoute] int orderId)
        {
            var request = new RemoveOrderRequest()
            {
                OrderId = orderId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{orderId}")]
        public async Task<IActionResult> UpdateOrderItemById([FromRoute] int orderId, [FromBody] UpdateOrderRequest request)
        {
            request.OrderId = orderId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
