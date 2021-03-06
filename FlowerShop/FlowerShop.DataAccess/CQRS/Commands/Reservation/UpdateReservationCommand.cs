namespace FlowerShop.DataAccess.CQRS.Commands.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateReservationCommand : CommandBase<Reservation, Reservation>
    {
        public override async Task<Reservation> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Reservations.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}