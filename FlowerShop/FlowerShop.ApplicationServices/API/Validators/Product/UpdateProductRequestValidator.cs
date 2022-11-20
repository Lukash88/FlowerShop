namespace FlowerShop.ApplicationServices.API.Validators.Product
{
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FluentValidation;

    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            this.RuleFor(x => x.ProductId).NotNull().WithMessage("CHOOSE_NUMBER_GREATER_THAN_0");
            this.RuleFor(x => x.Name).Length(3, 30).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_30_CHARACTERS");
            this.RuleFor(x => x.ShortDescription).Length(5, 200).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_5_TO_200_CHARACTERS");
            this.RuleFor(x => x.LongDescription).Length(5, 500).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_500_CHARACTERS");
            this.RuleFor(x => (int)x.Category).InclusiveBetween(1, 4).WithMessage("CHOOSE_1_-_4");
            this.RuleFor(x => x.Price).NotEmpty().WithMessage("INSERT_VALUE");
        }
    }
}