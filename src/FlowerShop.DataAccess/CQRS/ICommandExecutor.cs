using FlowerShop.DataAccess.CQRS.Commands;

namespace FlowerShop.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}