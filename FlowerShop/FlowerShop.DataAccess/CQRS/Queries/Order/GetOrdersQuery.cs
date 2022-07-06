namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    using FlowerShop.DataAccess.Entities;
    using FlowerShop.DataAccess.Enums;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrdersQuery : QueryBaseWithSieve<List<Order>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<List<Order>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.Orders.AsNoTracking());

            return await query.ToListAsync();
        }
    }
}