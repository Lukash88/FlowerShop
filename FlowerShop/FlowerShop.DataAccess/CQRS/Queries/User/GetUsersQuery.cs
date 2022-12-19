namespace FlowerShop.DataAccess.CQRS.Queries.User
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetUsersQuery : QueryBaseWithSieve<IQueryable<User>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<User>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor)
        {
           var query = context.Users
               .Include(x => x.Orders)
               .AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}