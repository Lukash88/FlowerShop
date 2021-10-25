using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries
{
    public class GetFlowerQuery : QueryBase<Flower>
    {
        public int Id { get; init; }

        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            var flower = await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
            return flower;
        }
    }
}
