namespace FlowerShop.DataAccess.CQRS.Queries.Reservation
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetReservationsQuery : QueryBaseWithSieve<List<Reservation>>
    {
        public SieveModel SieveModel { get; set; }

        public async override Task<List<Reservation>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var request = sieveProcessor.Apply(SieveModel, context.Reservations.AsNoTracking());         

            return await request.ToListAsync();
        }                                                                                                                                         
    }
}