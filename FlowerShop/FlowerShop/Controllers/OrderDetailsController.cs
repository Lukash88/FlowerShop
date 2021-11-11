namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ApiControllerBase
    {
        public OrderDetailsController(IMediator mediator, ILogger<OrderDetailsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in OrderDetails");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrderDetails([FromQuery] GetOrderDetailsRequest request) =>
            await this.HandleRequest<GetOrderDetailsRequest, GetOrderDetailsResponse>(request);

        [HttpGet]
        [Route("{orderDetailId}")]
        public async Task<IActionResult> GetOrderDetailById([FromRoute] int orderDetailId )
        {
            var request = new GetOrderDetailByIdRequest()
            {
                OrderDetailId = orderDetailId
            };
            return await this.HandleRequest<GetOrderDetailByIdRequest, GetOrderDetailByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrderDetail([FromBody] AddOrderDetailRequest request) =>
            await this.HandleRequest<AddOrderDetailRequest, AddOrderDetailResponse>(request);

        [HttpDelete]
        [Route("{orderDetailId}")]
        public async Task<IActionResult> RemoveOrderDetailById([FromRoute] int orderDetailId)
        {
            var request = new RemoveOrderDetailRequest()
            {
                OrderDetailId = orderDetailId
            };

            return await this.HandleRequest<RemoveOrderDetailRequest, RemoveOrderDetailResponse>(request);
        }

        [HttpPut]
        [Route("{orderDetailId}")]
        public async Task<IActionResult> UpdateOrderDetailId([FromRoute] int orderDetailId, [FromBody] UpdateOrderDetailRequest request)
        {
            request.OrderDetailId = orderDetailId;

            return await this.HandleRequest<UpdateOrderDetailRequest, UpdateOrderDetailResponse>(request);
        }
    }
}
