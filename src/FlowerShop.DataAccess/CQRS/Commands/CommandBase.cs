using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands;

public abstract class CommandBase<TParameter, TResult>
{
    public required TParameter Parameter { get; init; }

    public abstract Task<TResult> Execute(FlowerShopStorageContext context);
}