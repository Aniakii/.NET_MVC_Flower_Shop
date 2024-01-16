using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kwiatostan.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public required int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;


        [Required]
        public required int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        public required int Quantity {  get; set; }

        public decimal CalculateTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
