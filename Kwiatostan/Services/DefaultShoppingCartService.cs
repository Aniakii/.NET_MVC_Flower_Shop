using Kwiatostan.Data;
using Kwiatostan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

namespace Kwiatostan.Services
{
    public class DefaultShoppingCartService : IShoppingCartService
    {
        private readonly ILogger<DefaultShoppingCartService> _logger;
        private readonly ApplicationDbContext _context;

        public DefaultShoppingCartService(ILogger<DefaultShoppingCartService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ShoppingCart GetOrCreateCartForUser(string userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Null passed as userId.");
            }

            var cart = _context.ShoppingCarts
                .Include(sc => sc.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(sc => sc.UserId == userId);

            if (cart == null)
            {
                cart = new ShoppingCart { UserId = userId , CartItems = new List<CartItem>() };
                _context.ShoppingCarts.Add(cart);
                _context.SaveChanges();
            }

            return cart;
        }

        public bool AddProductToCart(string userId, int productId)
        {
            var cart = GetOrCreateCartForUser(userId);
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if(product == null || product.StockQuantity == 0)  { throw new ArgumentException("Quantity 0 or product doesn't exist anymore"); }

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.ShoppingCartId == cart.Id);
            if (cartItem == null)
            {
                cartItem = new CartItem { ProductId = productId, ShoppingCartId = cart.Id, Quantity = 1};
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            product.StockQuantity--;

            _context.SaveChanges();
            return true;
        }


        public bool RemoveProductFromCart(string userId, int productId)
        {
            var cart = GetOrCreateCartForUser(userId);
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.ShoppingCartId == cart.Id);

            if (cartItem == null || product == null)
            {
                throw new ArgumentException("Removal of non-exising cart item");
            }

            product.StockQuantity += cartItem.Quantity;
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return true;
        }

        public ICollection<CartItem> GetUserCartItems(string userId)
        {
            var cart = GetOrCreateCartForUser(userId);
            return cart.CartItems;
        }
    }
}
