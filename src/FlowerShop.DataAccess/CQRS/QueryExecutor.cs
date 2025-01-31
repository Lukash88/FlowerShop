using FlowerShop.DataAccess.CQRS.Queries;
using FlowerShop.DataAccess.Data;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS;

public class QueryExecutor(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
    : IQueryExecutor
{
    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(context);
    }

    public Task<TResult> ExecutePagedWithSieve<TResult>(QueryBasePagedWithSieve<TResult> query)
    {
        return query.Execute(context, sieveProcessor);
    }

    public Task<TResult> ExecuteWithSieve<TResult>(QueryBaseWithSieve<TResult> query)
    {
        return query.Execute(context, sieveProcessor);
    }
}