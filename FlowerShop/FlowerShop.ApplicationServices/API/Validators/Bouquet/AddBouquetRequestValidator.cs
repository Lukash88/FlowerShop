using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Bouquet
{
    public class AddBouquetRequestValidator : AbstractValidator<AddBouquetRequest>
    {
        public AddBouquetRequestValidator()
        {
            this.RuleFor(x => (int)x.Occasion).NotNull().NotEmpty().InclusiveBetween(1, 25)
                .WithMessage("Choose number between 1-25");
            this.RuleFor(x => (int)x.TypeOfArrangement).NotNull().NotEmpty().InclusiveBetween(1, 16)
                .WithMessage("Choose number between 1-16");
            this.RuleFor(x => (int)x.DecorationWay).NotNull().NotEmpty().InclusiveBetween(0,2)
                .WithMessage("Choose 1 or 2");
        }
    }
}