namespace FlowerShop.DataAccess.CQRS
{
    using FlowerShop.DataAccess.CQRS.Queries;
    using System.Threading.Tasks;

    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
        Task<TResult> Execute<TResult>(QueryBaseWithSieve<TResult> query);
    }
}