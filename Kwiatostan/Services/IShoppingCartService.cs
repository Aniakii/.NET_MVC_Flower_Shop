using Kwiatostan.Models;

namespace Kwiatostan.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetOrCreateCartForUser(string userId);
        ICollection<CartItem> GetUserCartItems(string userId);

        bool AddProductToCart(string userId, int productId); 
        bool RemoveProductFromCart(string userId, int productId);
    }
}
