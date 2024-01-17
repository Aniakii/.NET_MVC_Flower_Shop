using Kwiatostan.Data;
using Kwiatostan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kwiatostan.Controllers
{
    [ValidateAntiForgeryToken]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CheckoutController> _logger;
        private readonly IShoppingCartService _shoppingCartService;

        public CheckoutController(ApplicationDbContext context, ILogger<CheckoutController> logger, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Shipping()
        {
            return View();
        }

    }
}
