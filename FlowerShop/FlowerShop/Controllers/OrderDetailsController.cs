using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
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

        //[HttpGet]
        //[Route("{orderDetailId}")]
        //public async Task<IActionResult> GetOrderDetailById([FromRoute] GetOrderDetailsRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
