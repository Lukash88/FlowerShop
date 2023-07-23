using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.Data
{
    public class FlowerShopStorageContext : DbContext
    {
        public FlowerShopStorageContext(DbContextOptions<FlowerShopStorageContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BouquetFlower> BouquetFlowers { get; set; }
        public DbSet<BouquetOrderDetail> BouquetOrderDetails { get; set; }
        public DbSet<DecorationOrderDetail> DecorationOrderDetails { get; set; }
        public DbSet<ProductOrderDetail> ProductOrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BouquetConfiguration());
            modelBuilder.ApplyConfiguration(new BouquetFlowerConfiguration());
            modelBuilder.ApplyConfiguration(new BouquetOrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new DecorationConfiguration());
            modelBuilder.ApplyConfiguration(new BouquetOrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new FlowerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        }
    }
}