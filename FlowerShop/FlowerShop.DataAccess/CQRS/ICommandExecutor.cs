namespace FlowerShop.DataAccess.CQRS
{
    using FlowerShop.DataAccess.CQRS.Commands;
    using System.Threading.Tasks;

    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
