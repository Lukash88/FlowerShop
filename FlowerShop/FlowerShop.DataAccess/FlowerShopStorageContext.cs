using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlowerShop.DataAccess
{
    public class FlowerShopStorageContext : DbContext
    {
        public FlowerShopStorageContext(DbContextOptions<FlowerShopStorageContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationState> ReservationStates { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Flower> Flowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (Assembly.GetExecutingAssembly());
        }
    }
}