using Kwiatostan.Models;

namespace Kwiatostan.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetOrCreateCartForUser(string userId);
        ICollection<CartItem> GetUserCartItems(string userId);

        bool AddProductToCart(string userId, int productId);

        bool AddBouquetToCart(string userId, int bouquetId);
        bool UpdateQuantity(string userId, int articleId, string quantity, string articleType);
        bool RemoveProductFromCart(string userId, int productId);
        bool RemoveBouquetFromCart(string userId, int bouquetId);
    }
}
