namespace FlowerShop.ApplicationServices.API.Validators.Decoration
{
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FluentValidation;

    public class AddDecorationRequestValidator : AbstractValidator<AddDecorationRequest>
    {
        public AddDecorationRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(3, 100).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_500_CHARACTERS");
            this.RuleFor(x => (int)x.Role).InclusiveBetween(1, 2).WithMessage("CHOOSE_1_OR_2");
            this.RuleFor(x => x.Description).Length(5, 500).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_5_TO_500_CHARACTERS");
            this.RuleFor(x => x.IsAvailable).Must(x => x == false || x == true);
            this.RuleFor(x => x.Price).NotEmpty().WithMessage("INSERT_VALUE");
        }
    }
} 