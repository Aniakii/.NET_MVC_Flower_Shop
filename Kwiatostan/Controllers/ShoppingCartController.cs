using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kwiatostan.Data;
using Kwiatostan.Models;
using Microsoft.AspNetCore.Authorization;
using Kwiatostan.Services;
using Microsoft.AspNetCore.Identity;
using Kwiatostan.Helpers;

namespace Kwiatostan.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(ApplicationDbContext context,
            IShoppingCartService shoppingCartService,
            UserManager<IdentityUser> userManager,
            ILogger<ShoppingCartController> logger)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: ShoppingCart
        public  IActionResult Index()
        {
            var userId = _userManager.GetUserId(User) ?? throw new AccessViolationException("Only logged in users can access their cart");
            var cartItems = _shoppingCartService.GetUserCartItems(userId);
            var totalPrice = _shoppingCartService.GetOrCreateCartForUser(userId).CalculateTotal();

            ViewBag.TotalPrice = totalPrice;

            return View(cartItems);
        }





        [HttpPost]
        public IActionResult DeleteProductFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User) ?? throw new AccessViolationException("Only logged in users can access their cart");
            _shoppingCartService.RemoveProductFromCart(userId, productId);

            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
