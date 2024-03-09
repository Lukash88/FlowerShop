using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    public class GetBouquetQuery : QueryBase<Core.Entities.Bouquet>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Bouquet> Execute(FlowerShopStorageContext context) 
            => await context.Bouquets
                .FirstOrDefaultAsync(x => x.Id == Id);
    }
}