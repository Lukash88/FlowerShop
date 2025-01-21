using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Reservation;

public class RemoveReservationCommand : CommandBase<Core.Entities.Reservation, Core.Entities.Reservation>
{
    public override async Task<Core.Entities.Reservation> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Reservations.Remove(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}