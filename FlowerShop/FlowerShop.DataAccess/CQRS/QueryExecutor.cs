using FlowerShop.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly FlowerShopStorageContext context;

        public QueryExecutor(FlowerShopStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
