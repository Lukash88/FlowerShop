namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sieve.Models;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ApiControllerBase
    {
        public OrdersController(IMediator mediator, ILogger<OrdersController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Orders");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrders([FromQuery] SieveModel sieveModel)
        {
            GetOrdersRequest request = new GetOrdersRequest { SieveModel = sieveModel };
            
            return await this.HandleRequest<GetOrdersRequest, GetOrdersResponse>(request);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var request = new GetOrderByIdRequest()
            {
                OrderId = orderId
            };

            return await this.HandleRequest<GetOrderByIdRequest, GetOrderByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request) =>
            await this.HandleRequest<AddOrderRequest, AddOrderResponse>(request);

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> RemoveOrderById([FromRoute] int orderId)
        {
            var request = new RemoveOrderRequest()
            {
                OrderId = orderId
            };

            return await this.HandleRequest<RemoveOrderRequest, RemoveOrderResponse>(request);
        }

        [HttpPut]
        [Route("{orderId}")]
        public async Task<IActionResult> UpdateOrderById([FromRoute] int orderId, [FromBody] UpdateOrderRequest request)
        {
            request.OrderId = orderId;

            return await this.HandleRequest<UpdateOrderRequest, UpdateOrderResponse>(request);
        }
    }
}