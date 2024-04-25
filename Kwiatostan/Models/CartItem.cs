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
        public required int ArticleId { get; set; }
        public Article Article { get; set; } = null!;

        [Required]
        public required int Quantity { get; set; }

        public decimal CalculateTotal()
        {
            return Article.Price * Quantity;
        }
    }
}
