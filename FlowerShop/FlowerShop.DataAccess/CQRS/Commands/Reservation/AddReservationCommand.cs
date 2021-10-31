namespace FlowerShop.DataAccess.CQRS.Commands.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddReservationCommand : CommandBase<Reservation, Reservation>
    {
        public override async Task<Reservation> Execute(FlowerShopStorageContext context)
        {
            await context.Reservations.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
