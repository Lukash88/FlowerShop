using FlowerShop.ApplicationServices.API.Domain.User;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.User;

public class AddUserRequestValidator : AbstractValidator<RegisterAppUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(2, 50).NotEmpty()
            .WithMessage("First name must contain 2 - 50 characters");

        RuleFor(x => x.LastName).NotNull().NotEmpty().Length(2, 50)
            .WithMessage("Last name must contain 2 - 50 characters");

        RuleFor(x => x.Email).NotNull().NotEmpty().Length(5, 50)
            .WithMessage("Email must contain 5 - 50 characters")
            .EmailAddress().WithMessage("Provide valid email format");

        RuleFor(x => x.Password).NotNull().NotEmpty().Length(8, 20)
            .WithMessage("Password must contain 8 - 20 characters")
            .Matches(@"(?=^.{8,20}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$")
            .WithMessage("Password must have 1 Uppercase, 1 Lowercase, 1 number and 1 non alphanumeric");

        RuleFor(x => x.Line1).Length(5, 100)
            .WithMessage("Line1 of address must contain 5-100 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Line1));
        
        RuleFor(x => x.Line2).Length(0, 100)
            .WithMessage("Line2 of address  can contain up to 100 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Line2));

        RuleFor(x => x.City).Length(2, 50)
            .WithMessage("City must contain 2-50 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.City));
        
        RuleFor(x => x.State).Length(2, 50)
            .WithMessage("State must contain 2-50 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.State));

        RuleFor(x => x.PostalCode).Length(3, 20)
            .WithMessage("Postal code must contain 3-20 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.PostalCode));
        
        RuleFor(x => x.Country).Length(2, 100)
            .WithMessage("Postal code must contain 2-20 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Country));
    }
}