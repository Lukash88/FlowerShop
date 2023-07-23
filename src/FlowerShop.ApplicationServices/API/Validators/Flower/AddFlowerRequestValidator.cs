using FlowerShop.ApplicationServices.API.Domain.Flower;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Flower
{
    public class AddFlowerRequestValidator : AbstractValidator<AddFlowerRequest>
    {
        public AddFlowerRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            this.RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 100)
                .WithMessage("Name must contain 3-100 characters");
            this.RuleFor(x => (int)x.FlowerType).NotNull().NotEmpty().InclusiveBetween(1, 3)
                .WithMessage("Choose number between 1-3");
            this.RuleFor(x => x.Description).NotNull().NotEmpty().Length(5, 500)
                .WithMessage("Description must contain 5-500 characters");
            this.RuleFor(x => x.LengthInCm).NotNull().NotEmpty().InclusiveBetween(1, 500)
                .WithMessage("Choose length between 1-500 cm");
            this.RuleFor(x => (int)x.Color).NotNull().NotEmpty().InclusiveBetween(1, 10)
                .WithMessage("Choose color between 1-10");
            this.RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}