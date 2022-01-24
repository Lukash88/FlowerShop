namespace FlowerShop.ApplicationServices.API.Validators.User
{
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FluentValidation;

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            this.RuleFor(x => x.UserId).NotNull().WithMessage("CHOOSE_NUMBER_GREATER_THAN_0");
            this.RuleFor(x => (int)x.Role).InclusiveBetween(1, 3).NotEmpty().WithMessage("CHOOSE_1_-_3");
            this.RuleFor(x => x.FirstName).Length(2, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_2_TO_50_CHARACTERS");
            this.RuleFor(x => x.SecondName).Length(2, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_2_TO_50_CHARACTERS");
            this.RuleFor(x => x.UserName).Length(3, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_50_CHARACTERS");
            this.RuleFor(x => x.Password).Length(5, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_5_TO_50_CHARACTERS");
            this.RuleFor(x => x.Email).Length(5, 50).EmailAddress().NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_5_TO_50_CHARACTERS");
            this.RuleFor(x => x.Street).Length(3, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_50_CHARACTERS");
            this.RuleFor(x => x.PostalCode).Length(3, 20).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_20_CHARACTERS");
            this.RuleFor(x => x.City).Length(3, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_50_CHARACTERS");
        }
    }
}