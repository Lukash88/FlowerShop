namespace FlowerShop.ApplicationServices.API.Domain.ReservationState
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class GetReservationStatesRequest : IRequest<GetReservationStatesResponse>
    {
        public ReservationStateEnum ReservationStatus { get; init; }
    }
}
