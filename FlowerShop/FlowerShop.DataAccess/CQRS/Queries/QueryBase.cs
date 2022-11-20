using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(FlowerShopStorageContext context);
    }
}