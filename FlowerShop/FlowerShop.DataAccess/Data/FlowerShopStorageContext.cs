using System.Reflection;
using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.Data
{
    public class FlowerShopStorageContext : DbContext
    {
        public FlowerShopStorageContext(DbContextOptions<FlowerShopStorageContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
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
            modelBuilder.ApplyConfigurationsFromAssembly
                (Assembly.GetExecutingAssembly());
        }
    }
}