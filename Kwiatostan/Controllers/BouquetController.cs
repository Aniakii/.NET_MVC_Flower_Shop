using Kwiatostan.Data;
using Kwiatostan.Helpers;
using Kwiatostan.Models;
using Kwiatostan.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Kwiatostan.Controllers
{
    public class BouquetController : Controller
    {

        private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
        private readonly IShoppingCartService _shoppingCartService;
        private static readonly string pattern = @"product(\d+)";

        public BouquetController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IShoppingCartService shoppingCartService)
        {
            _context = context;
            _userManager = userManager;
            _shoppingCartService = shoppingCartService;
        }
		public IActionResult Index()
        {
            List<Product> flowers = _context.Products.Where(p => p.CategoryId == 1).ToList();
            List<Product> accessories = _context.Products.Where(p => p.CategoryId == 4).ToList();

            (Dictionary<Product, int> chosenFlowers, Dictionary<Product, int> chosenAccesories) = getProductsFromCookies();

            ViewBag.AvaibleFlowers = flowers;
            ViewBag.AvaibleAccesories = accessories;
            ViewBag.ChosenFlowers = chosenFlowers;
            ViewBag.ChosenAccesories = chosenAccesories;

            return View();
        }

        [HttpPost]
        public IActionResult AddToBouquet(int productId)
        {
            if (Request.Cookies[$"product{productId}"] != null)
            {
                UpdateBouquet(productId, "increase");

			} else
            {
                SetCookie($"product{productId}", "1", 7);
            }
			
			return RedirectToAction(nameof(Index));
		}

        [HttpPost]
        public IActionResult UpdateBouquet(int productId, string quantity)
        {
			foreach (var cookie in Request.Cookies)
			{
				string key = cookie.Key;
				if (int.TryParse(cookie.Value, out int value))
				{
					Match match = Regex.Match(key, pattern);
					if (match.Success)
					{
						int foundId = int.Parse(match.Groups[1].Value);

						if (foundId == productId)
						{
							if (quantity == "increase")
							{
								value++;
							}
							else
							{
								value--;
							}
                            int productCategoryId = _context.Products.FirstOrDefault(p => p.Id == foundId).CategoryId;

							if (value > 0 && value < 501 && productCategoryId == 1)
							{
								SetCookie(key, value.ToString(), 7);
							} else if (value > 0 && value < 16)
                            {
								SetCookie(key, value.ToString(), 7);
							} else
                            {
                                AlertHelper.SetAlert(this, "Nie możesz dodać większej ilości tego produktu", AlertType.warning, 500);
                            }

						}
					}
				}
			}

			return RedirectToAction(nameof(Index));
        }

		[HttpPost]
		public IActionResult DeleteProduct(int productId)
        {
			string cookieKey = $"product{productId}";
			var cookie = Request.Cookies[cookieKey];
			Response.Cookies.Delete(cookieKey);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult SaveBouquet()
		{


            (Bouquet createdBouquet, List<BouquetProduct> bouquetProducts) = CreateBouquet();

            _context.BouquetProducts.AddRange(bouquetProducts);

            _context.Bouquets.Add(createdBouquet);

			_context.SaveChanges();

            AlertHelper.SetAlert(this, "Bukiet został pomyślnie zapisany", AlertType.success, 500);

            return RedirectToAction(nameof(Index));
		}

        [HttpPost]
        public IActionResult AddBouquetToCart()
        {
            (Bouquet createdBouquet, List<BouquetProduct> bouquetProducts) = CreateBouquet();

            _context.BouquetProducts.AddRange(bouquetProducts);

            _context.Bouquets.Add(createdBouquet);

			_context.SaveChanges();

			var userId = _userManager.GetUserId(User) ?? throw new AccessViolationException("Only logged users can add items");

            _shoppingCartService.AddBouquetToCart(userId, createdBouquet.Id);

            AlertHelper.SetAlert(this, "Bukiet został pomyślnie zapisany i dodany do koszyka", AlertType.success, 500);

            return RedirectToAction(nameof(Index));
		}


		public void SetCookie(string key, string value, int? numberOfDays = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfDays.HasValue)
            {
                option.Expires = DateTime.Now.AddDays(numberOfDays.Value);
            }
            Response.Cookies.Append(key, value, option);
        }

        public (Bouquet, List<BouquetProduct>) CreateBouquet()
        {
			
			(Dictionary<Product, int> chosenFlowers, Dictionary<Product, int> chosenAccesories) = getProductsFromCookies();
            List<BouquetProduct> bouquetProducts = new List<BouquetProduct>();

            List<Article> allArticles = _context.Products.ToList().Cast<Article>()
                            .Concat(_context.Bouquets.ToList().Cast<Article>())
                            .ToList();


            int bouquetId = 1;

			if (_context.Bouquets.Any())
            {
				List<Article> sortedArticles = allArticles.OrderBy(article => article.Id).ToList();
				bouquetId = sortedArticles.Last().Id + 1;
			}
           
            
            var userId = _userManager.GetUserId(User);
            decimal price = 0;

			/*int bouquetProductId = 1;

			if (_context.BouquetProducts.Any())
			{
				bouquetProductId = _context.BouquetProducts.OrderBy(p => p.Id).ToList().Last().Id + 1;
			}*/

            foreach (var flower in chosenFlowers)
            {
                price += flower.Key.Price * flower.Value;
                bouquetProducts.Add(new BouquetProduct
                {
                    BouquetId = bouquetId,
                    ProductId = flower.Key.Id,
                    Amount = flower.Value
                });


            }
            foreach (var accesory in chosenAccesories)
            {
                price += accesory.Key.Price * accesory.Value;
                bouquetProducts.Add(new BouquetProduct
                {
                    BouquetId = bouquetId,
                    ProductId = accesory.Key.Id,
                    Amount = accesory.Value
                });
            }


            Bouquet createdBouquet = new Bouquet
            {
                UserId = userId ?? "-1",
                Price = price,
                CreationTime = DateTime.Now,
                InvolvedProducts = bouquetProducts
            };

            return (createdBouquet, bouquetProducts);
        }

        public (Dictionary<Product, int>, Dictionary<Product, int>) getProductsFromCookies()
        {
            Dictionary<Product, int> chosenFlowers = new Dictionary<Product, int>();
            Dictionary<Product, int> chosenAccesories = new Dictionary<Product, int>();

            foreach (var cookie in Request.Cookies)
            {
                string key = cookie.Key;
                if (int.TryParse(cookie.Value, out int value))
                {
                    Match match = Regex.Match(key, pattern);
                    if (match.Success)
                    {
                        int productId = int.Parse(match.Groups[1].Value);

                        Product product = _context.Products.FirstOrDefault(c => c.Id == productId);
                        if (product != null)
                        {
                            if (product.CategoryId == 1)
                            {
                                chosenFlowers.Add(product, value);

							
                            }
                            else
                            {
								chosenAccesories.Add(product, value);

								
                            }
                        }
                    }
                }
            }

			return (chosenFlowers, chosenAccesories);
        }

		public bool CreateBouquet(Dictionary<Product, int> chosenFlowers, Dictionary<Product, int> chosenAccesories)
		{
			int flowersAmount = 0;
			int accesoriesAmount = 0;
			foreach (var flower in chosenFlowers)
			{
				flowersAmount += +flower.Value;
			}

			foreach (var accesory in chosenAccesories)
			{
				accesoriesAmount += +accesory.Value;
			}

			if (flowersAmount < 2 || flowersAmount > 500)
			{
				return false;
			}

			if (accesoriesAmount > 30)
			{
				return false;
			}

			return true;
		}

		
		public bool UpdateBouquet(Dictionary<Product, int> chosenFlowers, Dictionary<Product, int> chosenAccesories, string quantity, int productId, string productType)
		{
			if (productType == "flower")
			{
				foreach (var flowers in chosenFlowers)
				{

					if (flowers.Key.Id == productId)
					{
						int value = flowers.Value;
								if (quantity == "increase")
								{
									value++;
								}
								else
								{
									value--;
								}
								

								if (value > 0 && value < 501 )
								{
									return true;
								}
								
								else
								{
									return false;
								}

							
						
					}
				}
			} else
			{
				foreach (var accesory in chosenAccesories)
				{

					if (accesory.Key.Id == productId)
					{
						int value = accesory.Value;
						if (quantity == "increase")
						{
							value++;
						}
						else
						{
							value--;
						}


						if (value > 0 && value < 16)
						{
							return true;
						}

						else
						{
							return false;
						}



					}
				}
			}
			

			return true;
		}
	}
}
