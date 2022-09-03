namespace FlowerShop.DataAccess.CQRS.Queries.User
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetUserQuery : QueryBase<User>
    {
        public int? Id { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }

        public override async Task<User> Execute(FlowerShopStorageContext context) =>
            await context.Users
            .Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.UserName == this.UserName || 
                x.Email == this.Email || x.Id == Id);
    }
}