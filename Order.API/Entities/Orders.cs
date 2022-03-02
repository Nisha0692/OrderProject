using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.API.Entities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string RequestedPickupTime { get; set; }

        public PickupAddress PickupAddress { get; set; }

        public DeliveryAddress DeliveryAddress { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();

        public string PickupInstructions { get; set; }

        public string DeliveryInstructions { get; set; }
    }
}
