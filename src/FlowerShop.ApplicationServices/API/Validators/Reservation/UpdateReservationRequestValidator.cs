using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FluentValidation;

namespace FlowerShop.ApplicationServices.API.Validators.Reservation;

public class UpdateReservationRequestValidator : AbstractValidator<UpdateReservationRequest>
{
    public UpdateReservationRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Email).NotNull().NotEmpty().Length(5, 254)
            .WithMessage("Email must contain 5 - 254 characters")
            .EmailAddress().WithMessage("Provide valid email format");

        RuleFor(x => (int)x.ReservationStatus)
            .NotNull().NotEmpty()
            .InclusiveBetween(1, 5)
            .WithMessage("Choose status between 1-5");

        RuleFor(x => (int)x.EventType)
            .NotNull().NotEmpty()
            .InclusiveBetween(1, 18)
            .WithMessage("Choose event type between 1-18");

        RuleFor(x => x.EventDescription)
            .NotNull().NotEmpty()
            .Length(5, 500)
            .WithMessage("Description must contain 5-500 characters");

        RuleFor(x => x.EventAddressLine1)
            .NotNull().NotEmpty()
            .Length(5, 100)
            .WithMessage("Line1 of address must contain 5-100 characters");

        RuleFor(x => x.EventAddressLine2)
            .Length(0, 100)
            .WithMessage("Line2 of address  can contain up to 100 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.EventAddressLine2));

        RuleFor(x => x.EventCity)
            .NotNull().NotEmpty()
            .Length(2, 50)
            .WithMessage("City must contain 2-50 characters");

        RuleFor(x => x.EventState)
            .NotNull().NotEmpty()
            .Length(2, 50)
            .WithMessage("State must contain 2-50 characters");

        RuleFor(x => x.EventPostalCode)
            .NotNull().NotEmpty()
            .Length(3, 20)
            .WithMessage("Postal code must contain 3-20 characters");

        RuleFor(x => x.EventCountry)
            .NotNull().NotEmpty()
            .Length(2, 70)
            .WithMessage("Country must contain 2-70 characters");

        RuleFor(x => x.ServicePrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Service price must be greater than or equal to 0")
            .When(x => x.ServicePrice.HasValue);
    }
}