namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetBouquetQuery : QueryBase<Bouquet>
    {
        public int Id { get; init; }

        public override async Task<Bouquet> Execute(FlowerShopStorageContext context)
        {
            var bouquet = await context.Bouquets.FirstOrDefaultAsync(x => x.Id == this.Id);
            return bouquet;
        }
    }
}