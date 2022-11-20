namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetReservationsQuery : QueryBaseWithSieve<IQueryable<Reservation>>
    {
        public SieveModel SieveModel { get; set; }

        public async override Task<IQueryable<Reservation>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor)
        {
            var query = context.Reservations.AsNoTracking();

            return await Task.FromResult(query);
        }                                                                                                                                         
    }
}