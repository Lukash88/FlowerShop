using FlowerShop.ApplicationServices.API.Domain.Order;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Order;

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.BuyerEmail).NotNull().NotEmpty().Length(5, 50)
            .WithMessage("Email must contain 5 - 50 characters")
            .EmailAddress().WithMessage("Provide valid email format");

        RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());

        RuleFor(x => x.Invoice).Length(0, 500)
            .WithMessage("Invoice can contain up to 500 characters");

        RuleFor(x => x.Status).NotNull().NotEmpty()
            .WithMessage("Order Status cannot be empty or null");
    }
}