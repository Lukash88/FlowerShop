using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Decoration
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Services;
    using System.Threading.Tasks;

    public class GetDecorationQuery : QueryBase<Core.Entities.Decoration>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context) 
            => await context.Decorations.FirstOrDefaultAsync(x => x.Id == this.Id);            
    }
}