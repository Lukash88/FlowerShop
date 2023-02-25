using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.User
{
    using System.Threading.Tasks;

    public class RemoveUserCommand : CommandBase<Core.Entities.User, Core.Entities.User>
    {
        public override async Task<Core.Entities.User> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}