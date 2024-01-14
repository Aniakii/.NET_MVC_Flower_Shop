using System.ComponentModel.DataAnnotations;

namespace Kwiatostan.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public required string StatusName { get; set; }
    }
}
