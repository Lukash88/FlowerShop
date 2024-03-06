using FlowerShop.ApplicationServices.API.Domain.User;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.User
{
    public class UpdateUserAddressRequestValidator : AbstractValidator<UpdateUserAddressRequest>
    {
        public UpdateUserAddressRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(2, 50).NotEmpty()
                .WithMessage("First name must contain 2 - 50 characters");
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(2, 50)
                .WithMessage("Last name must contain 2 - 50 characters");
            RuleFor(x => x.Email).Length(5, 50)
                .WithMessage("Email must contain 5 - 50 characters")
                .EmailAddress().WithMessage("Provide valid email format");
            RuleFor(x => x.Street).NotNull().NotEmpty().Length(3, 50)
                .WithMessage("Street must contain 3-50 characters");
            RuleFor(x => x.City).NotNull().NotEmpty().Length(3, 50)
                .WithMessage("City must contain 3-50 characters");
            RuleFor(x => x.PostalCode).NotNull().NotEmpty().Length(4, 20)
                .WithMessage("Postal code must contain 4-20 characters");
        }
    }
}