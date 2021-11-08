namespace FlowerShop.ApplicationServices.API.Validators.Bouquet
{
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FluentValidation;

    public class UpdateBouquetRequestValidator : AbstractValidator<UpdateBouquetRequest>
    {
        public UpdateBouquetRequestValidator()
        {
            this.RuleFor(x => x.BouquetId).NotNull();
            this.RuleFor(x => (int) x.Occasion).InclusiveBetween(1, 25).WithMessage("CHOOSE_NUMBER_BETWEEN_1_-_25").NotEmpty();
            this.RuleFor(x => (int) x.TypeOfArrangement).InclusiveBetween(1, 16).WithMessage("CHOOSE_NUMBER_BETWEEN_1_-_16").NotEmpty();
            this.RuleFor(x => (int) x.DecorationWay).InclusiveBetween(0,2).WithMessage("CHOOSE_NUMBER_BETWEEN_0_-_2");
            this.RuleFor(x => x.Quantity).GreaterThan(0).NotEmpty();
        }
    }
}
