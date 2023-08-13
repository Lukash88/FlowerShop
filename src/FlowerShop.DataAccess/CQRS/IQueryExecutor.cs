using FlowerShop.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
        Task<TResult> ExecuteWithSieve<TResult>(QueryBaseWithSieve<TResult> query);
    }
}