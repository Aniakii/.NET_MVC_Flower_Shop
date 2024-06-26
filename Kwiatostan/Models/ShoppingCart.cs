﻿using System.ComponentModel.DataAnnotations;

namespace Kwiatostan.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = null!;

        public decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (CartItem item in CartItems)
            {
                total += item.CalculateTotal();
            }

            return total;
        }
    }
}
