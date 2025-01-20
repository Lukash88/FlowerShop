using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.DeliveryMethod;

public class AddDeliveryMethodRequestValidator : AbstractValidator<AddDeliveryMethodRequest>
{
    public AddDeliveryMethodRequestValidator()
    {
        RuleFor(x => x.ShortName).NotNull().NotEmpty().Length(1, 50)
            .WithMessage("Name must contain 1-50 characters");

        RuleFor(x => x.DeliveryTime).NotNull().NotEmpty().Length(1, 50)
            .WithMessage("Delivery time must contain 1-50 characters");

        RuleFor(x => x.Description).NotNull().NotEmpty().Length(3, 100)
            .WithMessage("Description time must contain 1-100 characters");

        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}