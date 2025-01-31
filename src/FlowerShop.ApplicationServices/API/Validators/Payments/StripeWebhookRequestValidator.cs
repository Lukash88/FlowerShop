using FlowerShop.ApplicationServices.API.Domain.Payment;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Payments;

public sealed class StripeWebhookRequestValidator : AbstractValidator<StripeWebhookRequest>
{
    public StripeWebhookRequestValidator()
    {
        RuleFor(x => x.Json).NotNull().NotEmpty()
            .WithMessage("JSON cannot be empty or null");

        RuleFor(x => x.StripeSignature).NotNull().NotEmpty()
            .WithMessage("Stripe Signature cannot be empty or null");
    }
}