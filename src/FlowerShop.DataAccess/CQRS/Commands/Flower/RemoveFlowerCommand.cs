﻿using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Flower;

public class RemoveFlowerCommand : CommandBase<Core.Entities.Flower, Core.Entities.Flower>
{
    public override async Task<Core.Entities.Flower> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Flowers.Remove(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}