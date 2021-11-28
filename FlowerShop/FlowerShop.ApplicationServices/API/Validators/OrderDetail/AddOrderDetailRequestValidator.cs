namespace FlowerShop.ApplicationServices.API.Validators.OrderDetail
{
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FluentValidation;

    public class AddOrderDetailRequestValidator : AbstractValidator<AddOrderDetailRequest>
    {
        public AddOrderDetailRequestValidator()
        {
            this.RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("CHOOSE_NUMBER_GREATER_THAN_0_AND_VALID_ORDER_ID");
            this.RuleFor(x => x.Description).Length(5, 200).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_5_TO_200_CHARACTERS");
            this.RuleFor(x => x.Category).Length(3, 100).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_100_CHARACTERS");
            this.RuleFor(x => x.Price).NotEmpty().WithMessage("INSERT_VALUE");
        }
    }
}