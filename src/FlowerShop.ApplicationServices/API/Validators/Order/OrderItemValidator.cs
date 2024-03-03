using FlowerShop.ApplicationServices.API.Domain.Models;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Order
{
    public class OrderItemValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Product Id cannot be empty or null")
                .GreaterThan(0).WithMessage("Order Id must be greater than 0");
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.ProductName).NotNull().NotEmpty().Length(3, 100)
                .WithMessage("Name must contain 3-100 characters");
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty().WithMessage("Image Url cannot be empty or null");
            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("Quantity cannot be empty or null")
                .InclusiveBetween(1, 1000).WithMessage("Quantity must be greater than 0 and less than 1000");
        }
    }
}