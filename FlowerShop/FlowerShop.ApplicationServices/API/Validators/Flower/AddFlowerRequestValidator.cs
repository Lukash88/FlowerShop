namespace FlowerShop.ApplicationServices.API.Validators.Flower
{
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FluentValidation;

    public class AddFlowerRequestValidator : AbstractValidator<AddFlowerRequest>
    {
        public AddFlowerRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(3, 100).NotEmpty();
            this.RuleFor(x => x.Description).Length(1, 500).NotEmpty();
            this.RuleFor(x => (int)x.FlowerType).InclusiveBetween(1, 3);
            this.RuleFor(x => x.LengthInCm).Must(x => x >= 0 && x <= 255).WithMessage("CHOOSE_LENGTH_BETWEEN_0_ - _255");
            this.RuleFor(x => (int)x.Colour).InclusiveBetween(1, 10);
        }
    }
}