using FlowerShop.DataAccess.CQRS.Commands;
using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly FlowerShopStorageContext _context;

        public CommandExecutor(FlowerShopStorageContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}