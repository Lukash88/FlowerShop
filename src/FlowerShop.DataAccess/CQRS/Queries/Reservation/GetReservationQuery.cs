using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    public class GetReservationQuery : QueryBase<Core.Entities.Reservation>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Reservation> Execute(FlowerShopStorageContext context) 
            => await context.Reservations.FirstOrDefaultAsync(x => x.Id == Id);
    }
}