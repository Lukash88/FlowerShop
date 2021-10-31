namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetReservationsQuery : QueryBase<List<Reservation>>
    {
        public string EventType { get; init; }

        public async override Task<List<Reservation>> Execute(FlowerShopStorageContext context)
        {
            var reservationsFilteredByEventType = !string.IsNullOrEmpty(EventType) ?
                await context.Reservations.Where(x => x.EventType.Contains(EventType)).ToListAsync() : await context.Reservations.ToListAsync();

            return reservationsFilteredByEventType;
        }
    }
}
