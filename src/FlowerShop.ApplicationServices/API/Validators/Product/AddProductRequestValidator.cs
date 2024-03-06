using FlowerShop.ApplicationServices.API.Domain.Product;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Product
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 100)
                .WithMessage("Name must contain 3-100 characters");
            RuleFor(x => x.ShortDescription).NotNull().NotEmpty().Length(5, 200)
                .WithMessage("Description must contain 5-200 characters");
            RuleFor(x => x.LongDescription).NotNull().NotEmpty().Length(5, 500)
                .WithMessage("Description must contain 5-500 characters");
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}