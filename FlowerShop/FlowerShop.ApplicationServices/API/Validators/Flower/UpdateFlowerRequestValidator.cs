namespace FlowerShop.ApplicationServices.API.Validators.Flower
{
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FluentValidation;

    public class UpdateFlowerRequestValidator : AbstractValidator<UpdateFlowerRequest>
    {
        public UpdateFlowerRequestValidator()
        {
            this.RuleFor(x => x.FlowerId).NotNull().WithMessage("CHOOSE_NUMBER_GREATER_THAN_0");
            this.RuleFor(x => x.Name).Length(3, 100).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_100_CHARACTERS");
            this.RuleFor(x => (int)x.FlowerType).InclusiveBetween(1, 3).WithMessage("CHOOSE_NUMBER_BETWEEN_1_-_3");
            this.RuleFor(x => x.Description).Length(1, 500).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_1_TO_500_CHARACTERS");
            this.RuleFor(x => x.LengthInCm).Must(x => x >= 0 && x <= 255).WithMessage("CHOOSE_LENGTH_BETWEEN_0_ - _255");
            this.RuleFor(x => (int)x.Colour).InclusiveBetween(1, 10).WithMessage("CHOOSE_NUMBER_BETWEEN_1_-_10");
            this.RuleFor(x => x.Price).NotEmpty().WithMessage("INSERT_VALUE");
        }
    }
}