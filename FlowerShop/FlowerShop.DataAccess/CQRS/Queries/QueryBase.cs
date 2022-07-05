using System.Threading.Tasks;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor);
    }
}
