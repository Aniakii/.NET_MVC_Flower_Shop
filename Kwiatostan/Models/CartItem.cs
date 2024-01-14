using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kwiatostan.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }
        public required ShoppingCart ShoppingCart { get; set; }


        [Required]
        public int ProductId { get; set; }
        public required Product Product { get; set; }

        [Required]
        public int Quantity {  get; set; }

        public decimal CalculateTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
