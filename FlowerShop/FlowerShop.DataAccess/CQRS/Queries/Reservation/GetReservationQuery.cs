namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetReservationQuery : QueryBase<Reservation>
    {
        public int Id { get; init; }

        public override async Task<Reservation> Execute(FlowerShopStorageContext context) =>                          
            await context.Reservations.FirstOrDefaultAsync(x => x.Id == this.Id);                                     
    }
}