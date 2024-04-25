using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Kwiatostan.Models
{
    public class Product: Article
	{
        

        [Required]
        public required string Name { get; set; }

        [AllowNull]
        public string? Description { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; } = null!;

        public  virtual List<CartItem> CartItems { get; set; } = null!;

        
    }

}
