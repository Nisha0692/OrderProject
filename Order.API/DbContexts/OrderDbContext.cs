using Order.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Order.API.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Orders> Order { get; set; } = null!;
        public DbSet<PickupAddress> PickupAddress { get; set; } = null!;
        public DbSet<DeliveryAddress> DeliveryAddress { get; set; } = null!;
        public DbSet<Item> Item { get; set; } = null!;

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            :base(options)
        {

        }

    }
}
