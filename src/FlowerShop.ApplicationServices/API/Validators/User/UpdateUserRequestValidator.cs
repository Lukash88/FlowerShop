using FlowerShop.ApplicationServices.API.Domain.User;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.User;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.DisplayName).NotNull().NotEmpty().Length(3, 50)
            .WithMessage("Display name must contain 2 - 50 characters");

        RuleFor(x => x.NewPassword).NotNull().NotEmpty().Length(8, 20)
            .WithMessage("Password must contain 8 - 20 characters")
            .Matches(@"(?=^.{8,20}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$")
            .WithMessage("Password must have 1 Uppercase, 1 Lowercase, 1 number and 1 non alphanumeric");
        
        RuleFor(x => x.Email).NotNull().NotEmpty().Length(5, 50)
            .WithMessage("Email must contain 5 - 50 characters")
            .EmailAddress().WithMessage("Provide valid email format");
    }
}