using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.API.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public string ItemCode { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public Orders? Order { get; set; }

        public int OrderId { get; set; }
    }
}