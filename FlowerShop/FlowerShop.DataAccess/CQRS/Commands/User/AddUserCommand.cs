namespace FlowerShop.DataAccess.CQRS.Commands.User
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(FlowerShopStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}