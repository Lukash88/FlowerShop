﻿namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetOrderDetailsQuery : QueryBaseWithSieve<List<OrderDetail>>
    {
        public SieveModel SieveModel { get; init; }

        public override async Task<List<OrderDetail>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.OrderDetails.AsNoTracking());

            return await query.ToListAsync();
        }
    }
}