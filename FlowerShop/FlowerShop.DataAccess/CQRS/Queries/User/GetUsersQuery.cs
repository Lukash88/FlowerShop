namespace FlowerShop.DataAccess.CQRS.Queries.User
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetUsersQuery : QueryBase<List<User>>
    {
        public string UserName { get; init; }

        public async override Task<List<User>> Execute(FlowerShopStorageContext context)
        {
            var usersFilteredByName = !string.IsNullOrEmpty(UserName) ?
                await context.Users.Where(x => x.UserName.Contains(UserName)).ToListAsync() : await context.Users.ToListAsync();

            return usersFilteredByName;
        }
    }
}
