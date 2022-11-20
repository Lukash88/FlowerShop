using FlowerShop.DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly FlowerShopStorageContext context;
        private readonly ISieveProcessor sieveProcessor;

        public QueryExecutor(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            this.context = context;
            this.sieveProcessor = sieveProcessor;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }

        public Task<TResult> ExecutePagedWithSieve<TResult>(QueryBasePagedWithSieve<TResult> query)
        {
            return query.Execute(this.context, this.sieveProcessor);
        }

        public Task<TResult> ExecuteWithSieve<TResult>(QueryBaseWithSieve<TResult> query)
        {
            return query.Execute(this.context, this.sieveProcessor);
        }
    }
}   