using FlowerShop.DataAccess.CQRS.Queries;

namespace FlowerShop.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
        Task<TResult> ExecuteWithSieve<TResult>(QueryBaseWithSieve<TResult> query);
    }
}