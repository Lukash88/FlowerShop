namespace FlowerShop.DataAccess.CQRS.Commands.User
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class RemoveUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}