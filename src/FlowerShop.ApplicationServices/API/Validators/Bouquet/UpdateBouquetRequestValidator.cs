using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Bouquet
{
    public class UpdateBouquetRequestValidator : AbstractValidator<UpdateBouquetRequest>
    {
        public UpdateBouquetRequestValidator()
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
            RuleFor(x => (int)x.Occasion).NotNull().NotEmpty().InclusiveBetween(1, 25)
                .WithMessage("Choose number between 1-25");
            RuleFor(x => (int)x.TypeOfArrangement).NotNull().NotEmpty().InclusiveBetween(1, 16)
                .WithMessage("Choose number between 1-16");
            RuleFor(x => (int)x.DecorationWay).NotNull().NotEmpty().InclusiveBetween(0, 2)
                .WithMessage("Choose 1 or 2");
        }
    }
}