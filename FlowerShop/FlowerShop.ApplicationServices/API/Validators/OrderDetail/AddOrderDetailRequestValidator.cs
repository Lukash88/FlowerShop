using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.OrderDetail
{
    public class AddOrderDetailRequestValidator : AbstractValidator<AddOrderDetailRequest>
    {
        public AddOrderDetailRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            this.RuleFor(x => x.OrderId).NotNull().NotEmpty().WithMessage("Order Id cannot be empty or null")
                .GreaterThan(0).WithMessage("Order Id must be greater than 0");
            this.RuleFor(x => x.Description).NotNull().NotEmpty().Length(5, 200)
                .WithMessage("Description must contain 5-200 characters");
            this.RuleFor(x => x.Category).NotNull().NotEmpty().Length(3, 100)
                .WithMessage("Category must contain 3-100 characters");
            this.RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}