using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    public class GetReservationsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Reservation>>
    {
        public SieveModel SieveModel { get; set; }

        public override async Task<IQueryable<Core.Entities.Reservation>> Execute(FlowerShopStorageContext context,
            ISieveProcessor sieveProcessor)
        {
            var query = context.Reservations.AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}