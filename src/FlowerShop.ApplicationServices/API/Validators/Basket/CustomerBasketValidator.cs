using FlowerShop.ApplicationServices.API.Domain.Models;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Basket
{
    public class CustomerBasketValidator : AbstractValidator<CustomerBasketDto>
    {
        public CustomerBasketValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty()
                .WithMessage("BasketId cannot be empty or null");
        }
    }
}