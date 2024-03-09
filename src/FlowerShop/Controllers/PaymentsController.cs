using System.Threading.Tasks;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlowerShop.Controllers
{
    [Authorize]
    public sealed class PaymentsController : ApiControllerBase
    {
        public PaymentsController(IMediator mediator, ILogger<PaymentsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Payments");
        }

        [HttpPost]
        [Route("{basketId}")]
        public async Task<IActionResult> AddOrUpdatePaymentIntent([FromRoute] string basketId,
            [FromBody] AddOrUpdatePaymentIntentRequest request)
        {
            request.BasketId = basketId;

            return await HandleRequest<AddOrUpdatePaymentIntentRequest, AddOrUpdatePaymentIntentResponse>(request);
        }
    }
}