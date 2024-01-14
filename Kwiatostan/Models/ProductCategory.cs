using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Kwiatostan.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public required string Name { get; set; }
        public List<Product> Products { get; set; } = null!;
    }
}
