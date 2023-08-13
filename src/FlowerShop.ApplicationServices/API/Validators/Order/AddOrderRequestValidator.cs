using FlowerShop.ApplicationServices.API.Domain.Order;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Order
{
    public class AddOrderRequestValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.BuyerEmail).NotNull().NotEmpty().Length(5, 50)
                .WithMessage("Email must contain 5 - 50 characters")
                .EmailAddress().WithMessage("Provide valid email format");
            RuleFor(x => x.Invoice).Length(0, 500)
                .WithMessage("Invoice can contain up to 500 characters");
            RuleFor(x => x.Status).NotNull().NotEmpty()
                .WithMessage("Order Status cannot be empty or null");
        }    
    }
}