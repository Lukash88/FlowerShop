using FlowerShop.DataAccess.CQRS.Queries;
using FlowerShop.DataAccess.Data;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly FlowerShopStorageContext _context;
        private readonly ISieveProcessor _sieveProcessor;

        public QueryExecutor(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }

        public Task<TResult> ExecutePagedWithSieve<TResult>(QueryBasePagedWithSieve<TResult> query)
        {
            return query.Execute(_context, _sieveProcessor);
        }

        public Task<TResult> ExecuteWithSieve<TResult>(QueryBaseWithSieve<TResult> query)
        {
            return query.Execute(_context, _sieveProcessor);
        }
    }
}   