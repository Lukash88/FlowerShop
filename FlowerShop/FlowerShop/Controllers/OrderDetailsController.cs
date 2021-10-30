namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrderDetails([FromQuery] GetOrderDetailsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{orderDetailId}")]
        public async Task<IActionResult> GetOrderDetailById([FromRoute] int orderDetailId )
        {
            var request = new GetOrderDetailByIdRequest()
            {
                OrderDetailId = orderDetailId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrderDetail([FromBody] AddOrderDetailRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{orderDetailId}")]
        public async Task<IActionResult> RemoveOrderDetailById([FromRoute] int orderDetailId)
        {
            var request = new RemoveOrderDetailRequest()
            {
                OrderDetailId = orderDetailId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{orderDetailId}")]
        public async Task<IActionResult> UpdateOrderDetailId([FromRoute] int orderDetailId, [FromBody] UpdateOrderDetailRequest request)
        {
            var orderDetail = new UpdateOrderDetailRequest()
            {
                OrderDetailId = orderDetailId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
