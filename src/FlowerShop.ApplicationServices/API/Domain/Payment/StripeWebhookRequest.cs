using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Payment;

public sealed class StripeWebhookRequest : IRequest<StripeWebhookResponse>
{
    public required string Json { get; init; }
    public required string StripeSignature { get; init; }
}