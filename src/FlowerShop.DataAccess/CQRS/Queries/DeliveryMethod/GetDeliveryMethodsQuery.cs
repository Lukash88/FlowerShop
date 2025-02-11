﻿using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;

public class GetDeliveryMethodsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.OrderAggregate.DeliveryMethod>>
{
    public required SieveModel SieveModel { get; init; }

    public override async Task<IQueryable<Core.Entities.OrderAggregate.DeliveryMethod>> Execute(
        FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
    {
        var query = context.DeliveryMethods.AsNoTracking();

        return await Task.FromResult(query);
    }
}