using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Decoration
{
    public class UpdateDecorationRequestValidator : AbstractValidator<UpdateDecorationRequest>
    {
        public UpdateDecorationRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            this.RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 100)
                .WithMessage("Name must contain 3-100 characters");
            this.RuleFor(x => (int)x.Role).NotNull().NotEmpty().InclusiveBetween(1, 2)
                .WithMessage("Choose 1 or 2");
            this.RuleFor(x => x.Description).NotNull().NotEmpty().Length(5, 500)
                .WithMessage("Description must contain 5-500 characters");
            this.RuleFor(x => x.IsAvailable).NotNull().NotEmpty().Must(x => x == false || x == true);
            this.RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}