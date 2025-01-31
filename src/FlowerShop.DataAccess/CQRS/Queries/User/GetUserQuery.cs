using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.User;

public class GetUserQuery //: QueryBase<Core.Entities.User>
{
    //public int? Id { get; init; }
    //public string UserName { get; init; }
    //public string Email { get; init; }

    //public override async Task<Core.Entities.User> Execute(FlowerShopStorageContext context) =>
    //    await context.Users
    //    .Include(x => x.Orders)
    //    .FirstOrDefaultAsync(x => x.UserName == UserName || 
    //        x.Email == Email || x.Id == Id);
}