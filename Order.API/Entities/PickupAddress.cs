using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.API.Entities
{
    public class PickupAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PickupAddressId { get; set; }

        public string Unit { get; set; }

        public string Street { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        [ForeignKey("OrderId")]
        public Orders? Order { get; set; }

        public int OrderId { get; set; }

    }
}
