using FlowerShop.ApplicationServices.API.Domain.Order;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Order
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.OrderId).NotNull().NotEmpty().WithMessage("Order Id cannot be empty or null")
                .GreaterThan(0).WithMessage("Order Id must be greater than 0");
            RuleFor(x => x.BuyerEmail).NotNull().NotEmpty().Length(5, 50)
                .WithMessage("Email must contain 5 - 50 characters")
                .EmailAddress().WithMessage("Provide valid email format");
            RuleFor(x => x.Invoice).Length(0, 500)
                .WithMessage("Invoice can contain up to 500 characters");
            RuleFor(x => x.Status).NotNull().NotEmpty()
                .WithMessage("Order Status cannot be empty or null");;
        }
    }
}