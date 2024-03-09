using FlowerShop.ApplicationServices.API.Domain.User;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.User
{
    public class AddUserRequestValidator : AbstractValidator<RegisterAppUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(2, 50).NotEmpty()
                .WithMessage("First name must contain 2 - 50 characters");
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(2, 50)
                .WithMessage("Last name must contain 2 - 50 characters");
            RuleFor(x => x.DisplayName).NotNull().NotEmpty().Length(2, 50)
                .WithMessage("Display name must contain 2 - 50 characters");
            RuleFor(x => x.Password).NotNull().NotEmpty().Length(8, 20)
                .WithMessage("Password must contain 8 - 20 characters")
                .Matches("(?=^.{8,20}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$")
                .WithMessage("Password must have 1 Uppercase, 1 Lowercase, 1 number and 1 non alphanumeric");
            RuleFor(x => x.Email).NotNull().NotEmpty().Length(5, 50)
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