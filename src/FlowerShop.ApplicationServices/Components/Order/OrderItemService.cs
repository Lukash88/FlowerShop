using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.CartRepository;
using Microsoft.Extensions.Logging;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderItemService(
    ICartRepository cartRepository,
    IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor,
    ILogger<OrderItemService> logger) : IOrderItemService
{
    public async Task<List<OrderItem>> UpdateOrderItems(UpdateOrderRequest request)
    {
        var itemsToRemove = await GetOrderItems(request.Id);
        await RemoveOrderItems(itemsToRemove);

        var newOrderItems = await GenerateOrderItems(request.CartId!);

        return newOrderItems;
    }

    public async Task<List<OrderItem>> GenerateOrderItems(string cartId)
    {
        logger.LogInformation("Generating order items for cart: {CartId}", cartId);

        var cart = await cartRepository.GetCartAsync(cartId);

        if (cart is null)
        {
            throw new InvalidOperationException($"Cart {cartId} not found");
        }

        var orderItems = new List<OrderItem>();

        foreach (var item in cart.Items)
        {
            var product = await queryExecutor.Execute(new GetProductQuery
            {
                Id = item.ProductId
            });

            if (product is null)
            {
                throw new InvalidOperationException($"Product {item.ProductId} not found");
            }

            if (product.StockLevel < item.Quantity)
            {
                throw new InvalidOperationException(
                    $"Not enough stock for product {item.ProductName}. Available stock: {product.StockLevel}");
            }

            product.StockLevel -= item.Quantity;
            await commandExecutor.Execute(new UpdateProductCommand { Parameter = product });

            logger.LogInformation("Reduced stock for product {ProductId} ({ProductName}) by {Quantity}. New stock: {NewStock}",
                product.Id, product.Name, item.Quantity, product.StockLevel);

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

    public async Task AdjustStockForOrder(OrderEntity order, StockAdjustmentType adjustmentType)
    {
        var action = adjustmentType == StockAdjustmentType.Reduce ? "Reducing" : "Restoring";
        logger.LogInformation("{Action} stock for order {OrderId}", action, order.Id);

        foreach (var item in order.OrderItems)
        {
            var product = await queryExecutor.Execute(new GetProductQuery
            {
                Id = item.ItemOrdered.ProductItemId
            });

            if (product is null)
            {
                throw new InvalidOperationException(
                    $"Product {item.ItemOrdered.ProductItemId} not found for order {order.Id}");
            }

            if (adjustmentType == StockAdjustmentType.Reduce)
            {
                if (product.StockLevel < item.Quantity)
                {
                    throw new InvalidOperationException(
                        $"Not enough stock for product {item.ItemOrdered.ProductName}. " +
                        $"Available: {product.StockLevel}, Requested: {item.Quantity}");
                }
                product.StockLevel -= item.Quantity;
            }
            else
            {
                product.StockLevel += item.Quantity;
            }

            await commandExecutor.Execute(new UpdateProductCommand { Parameter = product });

            logger.LogInformation("{Action} stock for product {ProductId} by {Quantity}. New stock: {NewStock}",
                action, product.Id, item.Quantity, product.StockLevel);
        }
    }

    private async Task<List<OrderItem>> GetOrderItems(int orderId)
    {
        var getItemsQuery = new GetOrderItemsQuery
        {
            OrderId = orderId
        };

        return await queryExecutor.Execute(getItemsQuery);
    }

    private async Task<List<OrderItem>> RemoveOrderItems(List<OrderItem> items)
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