using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Catalog;

namespace Shop.Infrastructure.Data;

public static class SeedData
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "men"
            },
            new Category
            {
                Id = 2,
                Name = "women"
            }
        );

        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Men's Black Jacket",
                Description = "A stylish black jacket suitable for everyday wear and cool weather.",
                Price = 59,
                CategoryId = 1,
                ImageUrl = "/images/men/mens_jacket.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 2,
                Name = "Men's Running Shoes",
                Description = "Lightweight running shoes designed for comfort, support, and daily workouts.",
                Price = 59,
                CategoryId = 1,
                ImageUrl = "/images/men/mens_shoes.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 3,
                Name = "Men's Graphic Tee",
                Description = "A casual graphic T-shirt made for comfortable everyday outfits.",
                Price = 59,
                CategoryId = 1,
                ImageUrl = "/images/men/mens_tee.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 4,
                Name = "Men's Everyday Sneakers",
                Description = "Versatile everyday sneakers that pair easily with casual and sporty clothing.",
                Price = 59,
                CategoryId = 1,
                ImageUrl = "/images/men/mens_sneaker.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 5,
                Name = "Women's Summer Dress",
                Description = "A lightweight summer dress with a comfortable fit, ideal for warm-weather outings.",
                Price = 59,
                CategoryId = 2,
                ImageUrl = "/images/women/womens_dress.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 6,
                Name = "Women's Handbag",
                Description = "A practical and elegant handbag for carrying everyday essentials.",
                Price = 59,
                CategoryId = 2,
                ImageUrl = "/images/women/womens_bag.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 7,
                Name = "Women's Casual Tote",
                Description = "A spacious casual tote bag suitable for shopping, work, and daily use.",
                Price = 59,
                CategoryId = 2,
                ImageUrl = "/images/women/womens_tote.jpg",
                Quantity = 10
            },
            new Product
            {
                Id = 8,
                Name = "Women's Street Sneakers",
                Description = "Modern street-style sneakers combining everyday comfort with a sporty look.",
                Price = 59,
                CategoryId = 2,
                ImageUrl = "/images/women/womens_sneaker.jpg",
                Quantity = 10
            }
        );
    }
}
