using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands
{
using System.Threading.Tasks;

    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter { get; init; }

        public abstract Task<TResult> Execute(FlowerShopStorageContext context);
    }
}