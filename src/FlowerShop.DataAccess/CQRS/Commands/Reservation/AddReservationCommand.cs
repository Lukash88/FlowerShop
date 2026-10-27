using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Reservation;

public class AddReservationCommand : CommandBase<Core.Entities.ReservationAggregate.Reservation, Core.Entities.ReservationAggregate.Reservation>
{
    public override async Task<Core.Entities.ReservationAggregate.Reservation> Execute(FlowerShopStorageContext context)
    {
        await context.Reservations.AddAsync(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}