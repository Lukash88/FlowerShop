using Sieve.Services;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries
{
    public abstract class QueryBaseWithSieve<TResult>
    {
        public abstract Task<TResult> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor);
    }
}