using Order.API.Models;

namespace Order.API
{
    public class OrderDataStore
    {
        public List<OrderDto> Orders { get; set; }

        public static OrderDataStore Current { get; } = new OrderDataStore();

        public OrderDataStore()
        {
            Orders = new List<OrderDto>()
            {
                new OrderDto
                {
                    OrderId = 1,
                    PickupInstructions = "Pickup"
                }
            };
        }
    }
}
