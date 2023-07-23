using FlowerShop.ApplicationServices.API.Domain.Basket;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Basket
{
    public class UpdateBasketValidator : AbstractValidator<UpdateBasketRequest>
    {
        public UpdateBasketValidator()
        {
            this.RuleForEach(x => x.Items).SetValidator(new BasketItemValidator());
        }
    }
}