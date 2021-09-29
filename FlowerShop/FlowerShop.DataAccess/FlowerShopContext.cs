using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess
{
    public class FlowerShopContext : DbContext
    {
        public FlowerShopContext(DbContextOptions<FlowerShopContext> options) : base(options)
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Reservation> Users { get; set; }
        public DbSet<ReservationState> ReservationStatus { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Flower> Flowers { get; set; }
    }
}
