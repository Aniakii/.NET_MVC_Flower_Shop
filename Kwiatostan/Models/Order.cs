using System.ComponentModel.DataAnnotations;

namespace Kwiatostan.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int OrderStatusId { get; set; }
        public required OrderStatus OrderStatus { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }
        public required ShoppingCart ShoppingCart { get; set; }


        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
