using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Reservation
{
    public class AddReservationCommand : CommandBase<Core.Entities.Reservation, Core.Entities.Reservation>
    {
        public override async Task<Core.Entities.Reservation> Execute(FlowerShopStorageContext context)
        {
            await context.Reservations.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}