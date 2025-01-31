using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet;

public class GetBouquetQuery : QueryBase<Core.Entities.Bouquet>
{
    public required int Id { get; init; }

    public override async Task<Core.Entities.Bouquet> Execute(FlowerShopStorageContext context) 
        => await context.Bouquets
            .FirstOrDefaultAsync(x => x.Id == Id);
}