namespace FlowerShop.ApplicationServices.API.Validators.Reservation
{
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FluentValidation;

    public class UpdateReservationRequestValidator : AbstractValidator<UpdateReservationRequest>
    {
        public UpdateReservationRequestValidator()
        {
            this.RuleFor(x => x.ReservationId).NotNull().WithMessage("CHOOSE_NUMBER_GREATER_THAN_0_AND_VALID_RESERVATION_ID");
            this.RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("CHOOSE_NUMBER_GREATER_THAN_0_AND_VALID_ORDER_ID");
            this.RuleFor(x => (int)x.ReservationStatus).InclusiveBetween(1, 4).WithMessage("CHOOSE_1_-_4");
            this.RuleFor(x => (int)x.EventType).InclusiveBetween(1, 18).NotEmpty().WithMessage("CHOOSE_1_-_18");
            this.RuleFor(x => x.EventDescription).Length(5, 500).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_5_TO_500_CHARACTERS");
            this.RuleFor(x => x.EventStreet).Length(3, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_50_CHARACTERS");
            this.RuleFor(x => x.EventCity).Length(3, 50).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_3_TO_50_CHARACTERS");
            this.RuleFor(x => x.EventPostalCode).Length(4, 20).NotEmpty().WithMessage("STRING_MUST_CONTAIN_FROM_4_TO_20_CHARACTERS");
        }
    }
}