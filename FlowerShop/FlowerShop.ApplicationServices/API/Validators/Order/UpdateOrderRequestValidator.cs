using FlowerShop.ApplicationServices.API.Domain.Order;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Order
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
      
            this.RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("User Id cannot be empty or null")
                .GreaterThan(0).WithMessage("User Id must be greater than 0");
            this.RuleFor(x => x.IsPaymentConfirmed).NotNull().NotEmpty().Must(x => x == false || x == true);
            this.RuleFor(x => x.Invoice).Length(0, 500)
                .WithMessage("Invoice can contain up to 500 characters");
            this.RuleFor(x => (int)x.OrderState).NotNull().NotEmpty().InclusiveBetween(1, 3)
                .WithMessage("Choose number between 1-3");
            this.RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("Quantity cannot be empty or null")
                .InclusiveBetween(1, 1000).WithMessage("Quantity must be greater than 0 and less than 1000");
            this.RuleFor(x => x.Sum).NotEmpty().NotNull().NotEmpty().WithMessage("Sum cannot be empty or null")
                .GreaterThan(0).WithMessage("Sum must be greater than 0");
        }
    }
}