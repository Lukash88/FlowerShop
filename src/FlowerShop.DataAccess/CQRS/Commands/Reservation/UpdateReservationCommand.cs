using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Reservation;

public class UpdateReservationCommand : CommandBase<Core.Entities.ReservationAggregate.Reservation, Core.Entities.ReservationAggregate.Reservation>
{
    public override async Task<Core.Entities.ReservationAggregate.Reservation> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Reservations.Update(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}