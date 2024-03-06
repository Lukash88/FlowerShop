using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    public class GetFlowerQuery : QueryBase<Core.Entities.Flower>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Flower> Execute(FlowerShopStorageContext context) 
            => await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}