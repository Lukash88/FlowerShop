using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.CQRS.Queries.Decoration
{
    public class GetDecorationQuery : QueryBase<Core.Entities.Decoration>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context)
            => await context.Decorations.FirstOrDefaultAsync(x => x.Id == Id);
    }
}