namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using FlowerShop.DataAccess.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetReservationsQuery : QueryBase<List<Reservation>>
    {
        public EventType EventType { get; init; }

        public async override Task<List<Reservation>> Execute(FlowerShopStorageContext context)
        {                                                                                                                                         
            var reservationsFilteredByEventType = EventType != 0 ?                                                                                
                await context.Reservations.Where(x => x.EventType == EventType).ToListAsync() : await context.Reservations.ToListAsync();         

            return reservationsFilteredByEventType;
        }                                                                                                                                         
    }
}