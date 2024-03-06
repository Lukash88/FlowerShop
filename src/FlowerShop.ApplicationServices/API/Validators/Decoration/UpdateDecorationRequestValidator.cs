using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Decoration
{
    public class UpdateDecorationRequestValidator : AbstractValidator<UpdateDecorationRequest>
    {
        public UpdateDecorationRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            //RuleFor(x => x.DecorationId).NotNull().NotEmpty().WithMessage("Decoration Id cannot be empty or null")
            //    .GreaterThan(0).WithMessage("Decoration Id must be greater than 0");
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 100)
                .WithMessage("Name must contain 3-100 characters");
            RuleFor(x => x.ShortDescription).NotNull().NotEmpty().Length(5, 200)
                .WithMessage("Description must contain 5-200 characters");
            RuleFor(x => x.LongDescription).NotNull().NotEmpty().Length(5, 500)
                .WithMessage("Description must contain 5-500 characters");
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => (int)x.Role).NotNull().NotEmpty().InclusiveBetween(1, 2)
                .WithMessage("Choose 1 or 2");
        }
    }
}