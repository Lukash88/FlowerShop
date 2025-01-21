using FlowerShop.DataAccess.CQRS.Commands;
using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS;

public class CommandExecutor(FlowerShopStorageContext context) : ICommandExecutor
{
    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(context);
    }
}