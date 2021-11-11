namespace FlowerShop.ApplicationServices.API.Validators.OrderDetail
{
using System;
using System.Collections.Generic;
using System.Linq;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FluentValidation;

    public class UpdateOrderDetailRequestValidator : AbstractValidator<UpdateOrderDetailRequest>
    {
        public UpdateOrderDetailRequestValidator() 
        {
            this.RuleFor(x => x.OrderDetailId).NotNull();
            this.RuleFor(x => x.ReservationId).GreaterThan(0);
            this.RuleFor(x => x.ProductQuantity).InclusiveBetween(1, 1000).WithMessage("CHOOSE_QUANTITY_BETWEEN_1_-_1000").NotEmpty();
            this.RuleFor(x => x.CreatedAt).NotNull();
            this.RuleFor(x => (int)x.OrderState).InclusiveBetween(1, 3).WithMessage("CHOOSE_NUMBER_BETWEEN_1_-_3");
        }
    }
}
