using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.CartRepository;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderItemService(ICartRepository cartRepository, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor) : IOrderItemService
{
    public async Task<List<OrderItem>> UpdateOrderItems(UpdateOrderRequest request)
    {
        var itemsToRemove = await GetOrderItems(request.OrderId);
        await RemoveOrderItems(itemsToRemove);

        var newOrderItems = await GenerateOrderItems(request.CartId!);

        return newOrderItems;
    }

    public async Task<List<OrderItem>> GenerateOrderItems(string cartId)
    {
        var cart = await cartRepository.GetCartAsync(cartId);
        var orderItems = new List<OrderItem>();
        foreach (var item in cart.Items)
        {
            var product = await queryExecutor.Execute(new GetProductQuery
            {
                Id = item.ProductId
            });

            var orderItem = new OrderItem
            {
                ItemOrdered = new ProductItemOrdered
                {
                    ProductItemId = product.Id,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl
                },
                Price = product.Price,
                Quantity = item.Quantity
            };

            orderItems.Add(orderItem);
        }

        return orderItems;
    }

    public async Task<List<OrderItem>> GetOrderItems(int orderId)
    {
        var getItemsQuery = new GetOrderItemsQuery
        {
            OrderId = orderId
        };

        return await queryExecutor.Execute(getItemsQuery);
    }

    public async Task<List<OrderItem>> RemoveOrderItems(List<OrderItem> items)
    {
        var removeItemsCommand = new RemoveOrderItemsCommand
        {
            Parameter = items
        };

        return await commandExecutor.Execute(removeItemsCommand);
    }

    public decimal GetSubtotal(IEnumerable<OrderItem> items)
    {
        return items.Sum(item => item.Price * item.Quantity);
    }
}