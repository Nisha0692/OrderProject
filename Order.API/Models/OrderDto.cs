using System.ComponentModel.DataAnnotations;

namespace Order.API.Models
{
    public class OrderDto
    {
        public int? OrderId { get; set; }

        public string RequestedPickupTime { get; set; }

        public PickupAddress PickupAddress { get; set; }

        public DeliveryAddress DeliveryAddress { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();

        public string PickupInstructions { get; set; }

        public string DeliveryInstructions { get; set; }
    }
}
