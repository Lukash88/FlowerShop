using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Payment
{
    public sealed class StripeWebhookRequest : IRequest<StripeWebhookResponse>
    {
        public string Json { get; init; }
        public string StripeSignature { get; init; }
    }
}