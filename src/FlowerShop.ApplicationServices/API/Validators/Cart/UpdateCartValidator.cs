using FlowerShop.ApplicationServices.API.Domain.Cart;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Cart;

public class UpdateCartValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartValidator()
    {
        RuleForEach(x => x.Items).SetValidator(new CartItemValidator());
    }
}