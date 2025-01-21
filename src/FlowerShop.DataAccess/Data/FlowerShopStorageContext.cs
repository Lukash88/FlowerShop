using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.Data;

public sealed class FlowerShopStorageContext(DbContextOptions<FlowerShopStorageContext> options)
    : DbContext(options)
{
    public DbSet<Order> Orders { get; init; }
    public DbSet<OrderItem> OrderItems { get; init; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Decoration> Decorations { get; init; }
    public DbSet<Bouquet> Bouquets { get; init; }
    public DbSet<Flower> Flowers { get; init; }
    public DbSet<Reservation> Reservations { get; init; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BouquetConfiguration());
        modelBuilder.ApplyConfiguration(new DecorationConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryMethodConfiguration());
        modelBuilder.ApplyConfiguration(new FlowerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }
}