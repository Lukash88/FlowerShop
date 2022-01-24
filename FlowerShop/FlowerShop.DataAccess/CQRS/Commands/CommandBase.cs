namespace FlowerShop.DataAccess.CQRS.Commands
{
using System.Threading.Tasks;

    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter { get; set; }

        public abstract Task<TResult> Execute(FlowerShopStorageContext context);
    }
}