using FlowerShop.ApplicationServices.API.Domain.Payment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [AllowAnonymous]
        [HttpPost]
        [Route("webhook")]
        public async Task<IActionResult> StripeWebhook4()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();
            var stripeSignature = Request.Headers["Stripe-Signature"];

            var request = new StripeWebhookRequest
            {
                Json = json,
                StripeSignature = stripeSignature
            };

            return await HandleRequest<StripeWebhookRequest, StripeWebhookResponse>(request);
        }
    }
}