namespace FlowerShop.ApplicationServices.API.Validators.Decoration
{
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FluentValidation;

    public class AddDecorationRequestValidator : AbstractValidator<AddDecorationRequest>
    {
        public AddDecorationRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(3, 100).NotEmpty();
            this.RuleFor(x => (int)x.Role).InclusiveBetween(1, 2);
            this.RuleFor(x => x.Description).Length(5, 500).NotEmpty();
            this.RuleFor(x => x.IsAvailable).Must(x => x == false || x == true);
            this.RuleFor(x => x.Quantity).GreaterThan(0).NotEmpty();
            this.RuleFor(x => x.Price).NotEmpty();
            this.RuleFor(x => (int)x.TypeOfArrangement).InclusiveBetween(1, 16);
        }
    }
} 