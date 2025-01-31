using FlowerShop.ApplicationServices.API.Domain.Product;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Product;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
            
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 30)
            .WithMessage("Name must contain 3-30 characters");

        RuleFor(x => x.ShortDescription).NotNull().NotEmpty().Length(5, 200)
            .WithMessage("Description must contain 5-200 characters");

        RuleFor(x => x.LongDescription).NotNull().NotEmpty().Length(5, 500)
            .WithMessage("Description must contain 5-500 characters");

        RuleFor(x => (int)x.Category).NotNull().NotEmpty().InclusiveBetween(1, 4)
            .WithMessage("Choose category between 1-4");

        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be empty or null")
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.ImageUrl).NotNull().NotEmpty()
            .WithMessage("Image Url cannot be empty or null");

        RuleFor(x => x.ImageThumbnailUrl).NotNull()
            .NotEmpty().WithMessage("Image Url cannot be empty or null");
    }
}