using Kwiatostan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Kwiatostan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment)
            : base(options)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Kwiaty cięte" },
                new ProductCategory { Id = 2, Name = "Kwiaty doniczkowe" },
                new ProductCategory { Id = 3, Name = "Akcesoria ogrodnicze" }
            );


            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Róża czerwona",
                    Price = 19.99m,
                    CategoryId = 1,
                    ImageFilename = "roza.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Tulipan",
                    Price = 14.99m,
                    CategoryId = 1,
                    ImageFilename = "tulipan.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Fiołek doniczkowy",
                    Price = 12.50m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Storczyk",
                    Price = 29.99m,
                    CategoryId = 2,
                    ImageFilename = "storczyk.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Nawóz do roślin",
                    Price = 8.99m,
                    CategoryId = 3,
                    ImageFilename = "nawoz.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Narzędzia ogrodnicze",
                    Price = 24.99m,
                    CategoryId = 3
                }
            );
        }
    }
}
