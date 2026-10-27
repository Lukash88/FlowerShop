using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Reservation;

public class GetReservationsForUserQuery : QueryBaseWithSieve<IQueryable<Core.Entities.ReservationAggregate.Reservation>>
{
    public required SieveModel SieveModel { get; init; }
    public required string Email { get; init; }

    public override async Task<IQueryable<Core.Entities.ReservationAggregate.Reservation>> Execute(
        FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
    {
        var query = context.Reservations
            .Where(r => r.Email == Email)
            .Include(r => r.EventAddress)
            .AsNoTracking();

        return await Task.FromResult(query);
    }
}