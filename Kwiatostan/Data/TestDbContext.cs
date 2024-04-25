using Kwiatostan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kwiatostan.Data
{
	public class TestDbContext : IdentityDbContext
	{
		
		public DbSet<Article> Articles { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<Bouquet> Bouquets { get; set; }
		public DbSet<BouquetProduct> BouquetProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Article>().UseTptMappingStrategy();

			builder.Entity<ProductCategory>().HasData(
				new ProductCategory { Id = 1, Name = "Kwiaty cięte" },
				new ProductCategory { Id = 2, Name = "Kwiaty doniczkowe" },
				new ProductCategory { Id = 3, Name = "Akcesoria ogrodnicze" },
				new ProductCategory { Id = 4, Name = "Ozdoby" }
			);


			builder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Name = "Róża czerwona",
					Description = "Piękna czerwona róża, idealna na różne okazje.",
					Price = 19.99m,
					StockQuantity = 112,
					CategoryId = 1,
					ImageFilename = "roza.jpg"
				},
				new Product
				{
					Id = 2,
					Name = "Tulipan",
					Description = "Kolorowy tulipan, dodający świeżości i radości.",
					Price = 14.99m,
					StockQuantity = 12,
					CategoryId = 1,
					ImageFilename = "tulipan.jpg"
				},
				new Product
				{
					Id = 3,
					Name = "Fiołek doniczkowy",
					Price = 12.50m,
					StockQuantity = 44,
					CategoryId = 2
				},
				new Product
				{
					Id = 4,
					Name = "Storczyk",
					Description = "Elegancki storczyk, który doda uroku każdemu pomieszczeniu.",
					Price = 29.99m,
					StockQuantity = 0,
					CategoryId = 2,
					ImageFilename = "storczyk.jpg"
				},
				new Product
				{
					Id = 5,
					Name = "Nawóz do roślin",
					Description = "Skuteczny nawóz do roślin, aby utrzymać je zdrowe i piękne.",
					Price = 8.99m,
					StockQuantity = 150,
					CategoryId = 3,
					ImageFilename = "nawoz.jpg"
				},
				new Product
				{
					Id = 6,
					Name = "Narzędzia ogrodnicze",
					Price = 24.99m,
					StockQuantity = 15,
					CategoryId = 3
				},
				new Product
				{
					Id = 7,
					Name = "Różowa Wstążka",
					Description = "Urocza wstążka, idealna do ozdobienia bukietu.",
					Price = 4.99m,
					StockQuantity = 10,
					CategoryId = 4,
					ImageFilename = "wstazka.jpg"
				},
				new Product
				{
					Id = 8,
					Name = "Papier ozdobny",
					Description = "Klasyczny papier, idealny do ozdobienia bukietu.",
					Price = 1.99m,
					StockQuantity = 20,
					CategoryId = 4,
					ImageFilename = "papier.jpg"
				},
				new Product
				{
					Id = 9,
					Name = "Goździk czerwony",
					Description = "Czerwony goździk, dodający świeżości i radości.",
					Price = 9.99m,
					StockQuantity = 25,
					CategoryId = 1,
					ImageFilename = "gozdzik_czerwony.jpg"
				},
				 new Product
				 {
					 Id = 10,
					 Name = "Goździk różowy",
					 Description = "Różowy goździk, dodający świeżości i radości.",
					 Price = 9.99m,
					 StockQuantity = 25,
					 CategoryId = 1,
					 ImageFilename = "gozdzik_rozowy.jpg"
				 },
				  new Product
				  {
					  Id = 11,
					  Name = "Lilia",
					  Description = "Dostojny, elegancki kwiat.",
					  Price = 15.99m,
					  StockQuantity = 5,
					  CategoryId = 1,
					  ImageFilename = "lilia.jpg"
				  },
				   new Product
				   {
					   Id = 12,
					   Name = "Margaretka",
					   Description = "Urocza margaretka, dodająca radości.",
					   Price = 5.99m,
					   StockQuantity = 30,
					   CategoryId = 1,
					   ImageFilename = "margaretka.jpg"
				   },
				   new Product
				   {
					   Id = 13,
					   Name = "Słonecznik",
					   Description = "Urocza margaretka, dodająca radości.",
					   Price = 6.99m,
					   StockQuantity = 30,
					   CategoryId = 1,
					   ImageFilename = "slonecznik.jpg"
				   },
				   new Product
				   {
					   Id = 14,
					   Name = "Ozdobne zielone gałązki",
					   Description = "Zielone gałązki, idealnie otulają splecione w bukiet kwiaty.",
					   Price = 3.99m,
					   StockQuantity = 20,
					   CategoryId = 4,
					   ImageFilename = "galazki.jpg"
				   }
			);
		}
		public DbSet<Kwiatostan.Models.Address> Address { get; set; } = default!;
	}
}
