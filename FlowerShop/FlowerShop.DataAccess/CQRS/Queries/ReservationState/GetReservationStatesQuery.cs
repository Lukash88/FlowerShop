namespace FlowerShop.DataAccess.CQRS.Queries.ReservationState
{
    using FlowerShop.DataAccess.Entities;
    using FlowerShop.DataAccess.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetReservationStatesQuery : QueryBase<List<ReservationState>>
    {
        public ReservationStateEnum ReservationStatus { get; init; }

        public async override Task<List<ReservationState>> Execute(FlowerShopStorageContext context)
        {
            return await context.ReservationStates.ToListAsync();
            //var reservationStatesFilteredByState = !string.IsNullOrEmpty(ReservationStatus.ToString()) ?
            //await context.ReservationStates.Where(x => x.ReservationStatus.ToString().Contains(ReservationStatus.ToString())).ToListAsync() : await context.ReservationStates.ToListAsync();

            //return reservationStatesFilteredByState;
        }
    }
}
