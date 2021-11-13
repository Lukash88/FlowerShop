namespace FlowerShop.ApplicationServices.API.Validators.OrderItem
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FluentValidation;


    public class UpdateOrderItemRequestValidator : AbstractValidator<UpdateOrderItemRequest>
    {
        public UpdateOrderItemRequestValidator()
        {
            this.RuleFor(x => x.OrderItemId).GreaterThan(0);
            this.RuleFor(x => x.OrderDetailId).GreaterThan(0);
            this.RuleFor(x => x.Name).Length(3, 50).NotEmpty().WithMessage("NAME_MUST_CONTAIN_3_-_50_CHATACTERS");
            this.RuleFor(x => x.Description).Length(5, 200).NotEmpty().WithMessage("DESCRIPTION_MUST_CONTAIN_5_-_200_CHATACTERS");
            this.RuleFor(x => x.Category).Length(3, 200).NotEmpty().WithMessage("CATEGORY_NAME_MUST_CONTAIN_3_-_200_CHATACTERS");
            this.RuleFor(x => x.Price).NotEmpty();
        }
    }
}