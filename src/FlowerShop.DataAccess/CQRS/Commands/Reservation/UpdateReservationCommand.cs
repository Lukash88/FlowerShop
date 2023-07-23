using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Reservation
{
    using System.Threading.Tasks;

    public class UpdateReservationCommand : CommandBase<Core.Entities.Reservation, Core.Entities.Reservation>
    {
        public override async Task<Core.Entities.Reservation> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Reservations.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}