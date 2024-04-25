using Kwiatostan.Data;
using Kwiatostan.Models;
using Microsoft.CodeAnalysis;
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
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Null passed as userId.");
            }

            var cart = _context.ShoppingCarts
                .Include(sc => sc.CartItems)
                .ThenInclude(ci => ci.Article)
                .FirstOrDefault(sc => sc.UserId == userId);

            if (cart == null)
            {
                cart = new ShoppingCart { UserId = userId, CartItems = new List<CartItem>() };
                _context.ShoppingCarts.Add(cart);
                _context.SaveChanges();
            }

            return cart;
        }

        public bool AddProductToCart(string userId, int productId)
        {
            var cart = GetOrCreateCartForUser(userId);
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null || product.StockQuantity == 0) { throw new ArgumentException("Quantity 0 or product doesn't exist anymore"); }

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ArticleId == productId && ci.ShoppingCartId == cart.Id);
            if (cartItem == null)
            {
                cartItem = new CartItem { ArticleId = productId, ShoppingCartId = cart.Id, Quantity = 1 };
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
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ArticleId == productId && ci.ShoppingCartId == cart.Id);

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

        public bool AddBouquetToCart(string userId, int bouquetId)
        {
            var cart = GetOrCreateCartForUser(userId);
            Bouquet bouquet = _context.Bouquets.FirstOrDefault(p => p.Id == bouquetId);

            if (bouquet == null) { throw new ArgumentException("Quantity 0 or product doesn't exist anymore"); }

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ArticleId == bouquetId && ci.ShoppingCartId == cart.Id);
            if (cartItem == null)
            {
                cartItem = new CartItem { ArticleId = bouquetId, ShoppingCartId = cart.Id, Quantity = 1 };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
            return true;
        }

        public bool RemoveBouquetFromCart(string userId, int bouquetId)
        {
            var cart = GetOrCreateCartForUser(userId);
            Bouquet bouquet = _context.Bouquets.FirstOrDefault(p => p.Id == bouquetId);

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ArticleId == bouquetId && ci.ShoppingCartId == cart.Id);

            if (cartItem == null || bouquet == null)
            {
                throw new ArgumentException("Removal of non-exising cart item");
            }

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateQuantity(string userId, int articleId, string quantity, string articleType)
        {
            var cart = GetOrCreateCartForUser(userId);

            CartItem? cartItem = _context.CartItems.FirstOrDefault(ci => ci.ArticleId == articleId && ci.ShoppingCartId == cart.Id);
            if (cartItem != null)
            {
                if (quantity == "increase")
                {
                    cartItem.Quantity++;
                    if (articleType == "product")
                    {
                        var product = _context.Products.FirstOrDefault(p => p.Id == articleId);
                        product.StockQuantity += cartItem.Quantity;
                    }
                } else if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    if (articleType == "product")
                    {
                        Product product = _context.Products.FirstOrDefault(p => p.Id == articleId);
                        product.StockQuantity += cartItem.Quantity;
                    }
                } else {
                    if (articleType == "product")
                    {
                        RemoveProductFromCart(userId, articleId);
                    } else
                    {
                        RemoveBouquetFromCart(userId, articleId);
                    }
                }
            }
            _context.SaveChanges();
            return true;

        }
    }
}
