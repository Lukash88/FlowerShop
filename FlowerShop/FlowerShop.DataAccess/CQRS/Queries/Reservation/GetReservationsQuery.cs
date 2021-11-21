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

        public override Task<List<Reservation>> Execute(FlowerShopStorageContext context)
        {
            throw new System.NotImplementedException();
        }

        //public async override Task<List<Reservation>> Execute(FlowerShopStorageContext context)
        //{                                                                                                                                                            /// to be removed or renamed
        ////var reservationsFilteredByEventType = EventType != 0 ?                                                                                 /// to be removed or renamed
        ////    await context.Reservations.Where(x => x.EventType.Contains(EventType)).ToListAsync() : await context.Reservations.ToListAsync();                     /// to be removed or renamed

        ////return reservationsFilteredByEventType;             
        //}                                                                                                                                                            /// to be removed or renamed
    }
}
//Occasion != 0 ?
//               await context.Bouquets.Where(x => x.Occasion == Occasion).Include(x => x.Flowers).ToListAsync() :
//               await context.Bouquets.ToListAsync();
// var reservationsFilteredByEventType = !string.IsNullOrEmpty(EventType) ?                                                                                 /// to be removed or renamed
//                 await context.Reservations.Where(x => x.EventType.Contains(EventType)).ToListAsync() : await context.Reservations.ToListAsync();                     /// to be removed or renamed
