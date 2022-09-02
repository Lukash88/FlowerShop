namespace FlowerShop.DataAccess.CQRS.Queries.User
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetUsersQuery : QueryBaseWithSieve<List<User>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<List<User>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
           var request = sieveProcessor.Apply(SieveModel, 
               context.Users
               .Include(x => x.Orders)
               .AsNoTracking());

            return await request.ToListAsync();
        }
    }
}