using FlowerShop.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("api/flowershop")]

    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("orderItems")]
        public async Task<IActionResult> GetAllOrderItems([FromQuery] GetOrderItemRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
