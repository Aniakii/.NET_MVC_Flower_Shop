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
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ILogger<ShopController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public ShopController(ApplicationDbContext context,
            ILogger<ShopController> logger,
            IShoppingCartService shoppingCartService,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var carts = _context.ShoppingCarts.ToList();
            foreach(var cart in carts)
            {
                _logger.LogCritical(cart.UserId);
            }

            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var stockQuantityInfo = GetStockQuantityInfo(product.StockQuantity);

            ViewBag.StockQuantityAlertType = stockQuantityInfo.AlertType;
            ViewBag.StockQuantityMessage = stockQuantityInfo.Message;

            return View(product);
        }

        // POST: Products/AddToCart
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            AlertHelper.SetAlert(this, "Dodano do koszyka", AlertType.success, 500);

            var userId = _userManager.GetUserId(User) ?? throw new AccessViolationException("Only logged users can add items");

            _shoppingCartService.AddProductToCart(userId, productId);

            return RedirectToAction(nameof(Details), new {id = productId});
        }


        private static (string Message, string AlertType) GetStockQuantityInfo(int stockQuantity)
        {
            switch (stockQuantity)
            {
                case 0:
                    return ("Produkt chwilowo niedostępny", "alert-danger");

                case int n when n > 0 && n <= 15:
                    return ("Ostatnie sztuki, nie zwlekaj z zakupem!", "alert-warning");

                case int n when n > 15 && n <= 50:
                    return ("Produkt dostępny w umiarkowanej ilości", "alert-info");

                default:
                    return ("Produkt dostępny w bardzo dużej ilości", "alert-success");
            }
        }

    }
}
