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

namespace Kwiatostan.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
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
