using Kwiatostan.Data;
using Kwiatostan.Models;
using Kwiatostan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kwiatostan.Controllers
{
    [ValidateAntiForgeryToken]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CheckoutController> _logger;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<IdentityUser> _userManager;

        public CheckoutController(ApplicationDbContext context, ILogger<CheckoutController> logger, IShoppingCartService shoppingCartService,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }

        public IActionResult Shipping()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Shipping(Address address)
        {
            _logger.LogCritical(address.ToString());
            return View();
        }


    }
}
