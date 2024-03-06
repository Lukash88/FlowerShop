using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.User
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetUserQuery //: QueryBase<Core.Entities.User>
    {
        //public int? Id { get; init; }
        //public string UserName { get; init; }
        //public string Email { get; init; }

        //public override async Task<Core.Entities.User> Execute(FlowerShopStorageContext context) =>
        //    await context.Users
        //    .Include(x => x.Orders)
        //    .FirstOrDefaultAsync(x => x.UserName == this.UserName || 
        //        x.Email == this.Email || x.Id == Id);
    }
}