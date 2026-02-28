namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public sealed class PaymentSummary
{
    public int Last4 { get; init; }
    public required string Brand { get; init; }
    public int ExpMonth { get; init; }
    public int ExpYear { get; init; }
}