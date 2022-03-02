using Microsoft.EntityFrameworkCore;
using Order.API.DbContexts;
using Order.API.Entities;

namespace Order.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Orders> GetOrdersById(int orderId)
        {
            return await _context.Order.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Orders>> GetOrderAsync()
        {
            return await _context.Order.ToListAsync();
                
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<bool> OrderIdMatch(int orderId)
        {
            return await _context.Order.AnyAsync(o => o.OrderId == orderId);
        }
    }
}
