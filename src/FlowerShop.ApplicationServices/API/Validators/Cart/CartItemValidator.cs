using FlowerShop.ApplicationServices.API.Domain.Models;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Cart;

public class CartItemValidator : AbstractValidator<CartItemDto>
{
    public CartItemValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("CartId cannot be empty or null")
            .GreaterThan(0).WithMessage("CartId must be greater than 0");

        RuleFor(x => x.ImageUrl).NotNull().NotEmpty().WithMessage("Image Url cannot be empty or null");

        RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Product name cannot be empty or null");

        RuleFor(x => x.ShortDescription).NotNull().NotEmpty().WithMessage("Short description cannot be empty or null");
        
        RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("Quantity cannot be empty or null")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        
        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}