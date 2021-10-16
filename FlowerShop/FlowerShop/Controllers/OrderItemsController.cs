using FlowerShop.ApplicationServices.API.Domain.OrderItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrderItems([FromQuery] GetOrderItemsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        //[HttpGet]
        //[Route("{orderItemId}")]
        //public async Task<IActionResult> GetOrderItemById([FromRoute] GetOrderItemsRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
