namespace FlowerShop.DataAccess.CQRS.Queries.User
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; init; }

        public override async Task<User> Execute(FlowerShopStorageContext context) =>
            await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}