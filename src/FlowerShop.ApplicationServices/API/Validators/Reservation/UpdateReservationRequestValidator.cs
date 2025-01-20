using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Reservation;

public class UpdateReservationRequestValidator : AbstractValidator<UpdateReservationRequest>
{
    public UpdateReservationRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
            
        RuleFor(x => x.OrderId).NotNull().NotEmpty().WithMessage("Order Id cannot be empty or null")
            .GreaterThan(0).WithMessage("Order Id must be greater than 0");

        RuleFor(x => (int)x.ReservationStatus).NotNull().NotEmpty().InclusiveBetween(1, 4)
            .WithMessage("Choose status between 1-4");

        RuleFor(x => (int)x.EventType).NotNull().NotEmpty().InclusiveBetween(1, 18)
            .WithMessage("Choose event type between 1-18");

        RuleFor(x => x.EventDescription).NotNull().NotEmpty().Length(5, 500)
            .WithMessage("Description must contain 5-500 characters");

        RuleFor(x => x.EventStreet).NotNull().NotEmpty().Length(3, 50)
            .WithMessage("Street must contain 3-50 characters");

        RuleFor(x => x.EventCity).NotNull().NotEmpty().Length(3, 50)
            .WithMessage("City must contain 3-50 characters");

        RuleFor(x => x.EventPostalCode).NotNull().NotEmpty().Length(4, 20)
            .WithMessage("Postal code must contain 4-20 characters");
    }
}