using FlowerShop.ApplicationServices.API.Domain.Cart;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Cart;

public class RemoveCartValidator : AbstractValidator<RemoveCartRequest>
{
    public RemoveCartValidator()
    {
        RuleFor(x => x.CartId).NotNull().NotEmpty()
            .WithMessage("CartId cannot be empty or null");
    }
}