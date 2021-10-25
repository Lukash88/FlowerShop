using FlowerShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands
{
    public class UpdateFlowerCommand : CommandBase<Flower, Flower>
    {
        public int Id { get; init; }

        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            //var flowerId = await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
            //context.Flowers.Remove(flowerId);
            //await context.SaveChangesAsync();

            context.Flowers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

           // return flowerId;
        }
    }
}
