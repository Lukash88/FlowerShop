namespace FlowerShop.ApplicationServices.API.Validators.Order
{
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FluentValidation;

    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            this.RuleFor(x => x.OrderId).NotNull().WithMessage("CHOOSE_NUMBER_GREATER_THAN_0_AND_VALID_ORDER_ID");
            this.RuleFor(x => x.UserId).GreaterThan(0).WithMessage("CHOOSE_NUMBER_GREATER_THAN_0_AND_VALID_USER_ID");
            this.RuleFor(x => x.IsPaymentConfirmed).Must(x => x == false || x == true);
            this.RuleFor(x => x.Invoice).Length(0, 500).WithMessage("STRING_CAN_CONTAIN_MAX_500_CHARACTERS");
            this.RuleFor(x => (int)x.OrderState).InclusiveBetween(1, 3).WithMessage("CHOOSE_1_-_3");
            this.RuleFor(x => x.Quantity).InclusiveBetween(1, 1000).WithMessage("CHOOSE_QUANTITY_BETWEEN_1_1000");
            this.RuleFor(x => x.Sum).NotEmpty().WithMessage("INSERT_VALUE");
        }
    }
}