using FlowerShop.DataAccess.CQRS.Commands;
using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly FlowerShopStorageContext context;

        public CommandExecutor(FlowerShopStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}