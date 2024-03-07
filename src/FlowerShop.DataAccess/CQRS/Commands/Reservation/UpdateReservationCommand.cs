using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Reservation
{
    public class UpdateReservationCommand : CommandBase<Core.Entities.Reservation, Core.Entities.Reservation>
    {
        public override async Task<Core.Entities.Reservation> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Reservations.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}