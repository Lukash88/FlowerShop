using FlowerShop.ApplicationServices.API.Domain.Basket;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Basket
{
    public class RemoveBasketValidator : AbstractValidator<RemoveBasketRequest>
    {
        public RemoveBasketValidator()
        {
            RuleFor(x => x.BasketId).NotNull().NotEmpty()
                .WithMessage("BasketId cannot be empty or null");
        }
    }
}