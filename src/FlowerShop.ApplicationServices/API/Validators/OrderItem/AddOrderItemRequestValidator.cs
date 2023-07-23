namespace FlowerShop.ApplicationServices.API.Validators.OrderItem
{
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FluentValidation;

    public class AddOrderItemRequestValidator : AbstractValidator<AddOrderItemRequest>
    {
        public AddOrderItemRequestValidator()
        {
            this.RuleFor(x => x.OrderDetailId).NotNull();
            this.RuleFor(x => x.Name).Length(3, 50).NotEmpty().WithMessage("NAME_MUST_CONTAIN_3_-_50_CHATACTERS");
            this.RuleFor(x => x.Description).Length(5, 200).NotEmpty().WithMessage("DESCRIPTION_MUST_CONTAIN_5_-_200_CHATACTERS"); 
            this.RuleFor(x => x.Category).Length(3, 200).NotEmpty().WithMessage("CATEGORY_NAME_MUST_CONTAIN_3_-_200_CHATACTERS");
            this.RuleFor(x => x.Price).NotEmpty();
        }
    }
}