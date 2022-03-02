using Order.API.Entities;

namespace Order.API.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Orders>> GetOrderAsync();

        Task<Orders> GetOrdersById(int orderId);

        Task<bool> SaveChangesAsync();

        Task<bool> OrderIdMatch(int orderId);
    }
}
