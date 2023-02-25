using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.User
{
    using System.Threading.Tasks;

    public class AddUserCommand : CommandBase<Core.Entities.User, Core.Entities.User>
    {
        public override async Task<Core.Entities.User> Execute(FlowerShopStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}