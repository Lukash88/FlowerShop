using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.CQRS.Queries.Reservation;

public class GetReservationQuery : QueryBase<Core.Entities.ReservationAggregate.Reservation>
{
    public required int Id { get; init; }

    public override async Task<Core.Entities.ReservationAggregate.Reservation> Execute(FlowerShopStorageContext context)
    => await context.Reservations
        .Include(r => r.EventAddress)
        .FirstOrDefaultAsync(x => x.Id == Id);
}