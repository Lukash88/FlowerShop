using FlowerShop.ApplicationServices.API.Domain.User;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.User;

public class UpdateUserAddressRequestValidator : AbstractValidator<UpdateUserAddressRequest>
{
    public UpdateUserAddressRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Line1).NotNull().NotEmpty().Length(5, 100)
            .WithMessage("Line1 of address must contain 5-100 characters");

        RuleFor(x => x.Line2).Length(0, 100)
            .WithMessage("Line2 of address  can contain up to 100 characters");

        RuleFor(x => x.City).NotNull().NotEmpty().Length(2, 50)
            .WithMessage("City must contain 2-50 characters");

        RuleFor(x => x.State).NotNull().NotEmpty().Length(2, 50)
            .WithMessage("State must contain 2-50 characters");

        RuleFor(x => x.PostalCode).NotNull().NotEmpty().Length(3, 20)
            .WithMessage("Postal code must contain 3-20 characters");

        RuleFor(x => x.Country).NotNull().NotEmpty().Length(2, 100)
            .WithMessage("Postal code must contain 2-20 characters");
    }
}