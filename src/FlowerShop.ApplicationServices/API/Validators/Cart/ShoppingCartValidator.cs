using FlowerShop.ApplicationServices.API.Domain.Models;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Cart;

public class ShoppingCartValidator : AbstractValidator<ShoppingCartDto>
{
    public ShoppingCartValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty()
            .WithMessage("CartId cannot be empty or null");
    }
}