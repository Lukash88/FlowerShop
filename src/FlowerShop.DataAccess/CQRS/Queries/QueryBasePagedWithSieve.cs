﻿using FlowerShop.DataAccess.Data;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries;

public abstract class QueryBasePagedWithSieve<TResult>
{
    public abstract Task<TResult> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor);        
}