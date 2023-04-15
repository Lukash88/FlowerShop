using System.Threading.Tasks;
using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class OrderDetailsController : ApiControllerBase
    {
        public OrderDetailsController(IMediator mediator, ILogger<OrderDetailsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Order Details");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrderDetails([FromQuery] SieveModel sieveModel)
        {
            var request = new GetOrderDetailsRequest
            {
                SieveModel = sieveModel
            };

            return await this.HandleRequest<GetOrderDetailsRequest, GetOrderDetailsResponse>(request);
        }

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