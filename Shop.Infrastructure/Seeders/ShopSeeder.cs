using Microsoft.AspNetCore.Identity;
using Shop.Domain.Constants;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Catalog;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Seeders;

internal class ShopSeeder(ShopDbContext dbContext) : IShopSeeder
{
    public async Task Seed()
    {
        if (!dbContext.Categories.Any())
        {
            IEnumerable<Category> categories = GetCategories();
            await dbContext.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Products.Any())
        {
            IEnumerable<Product> products = GetProducts();
            await dbContext.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Roles.Any())
        {
            IEnumerable<IdentityRole> roles = GetRoles();
            await dbContext.AddRangeAsync(roles);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Users.Any())
        {
            IEnumerable<User> users = GetUsers();
            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();
        }
    }

    private IEnumerable<Category> GetCategories()
    {
        IEnumerable<Category> categories = [
            new ()
            {
                Id = Guid.Parse("a7f3c821-4b92-4d16-9e35-72c8f1a604b9"),
                Name = "Mobile",
                Description = "For calling and playing"
            },
            new ()
            {
                Id = Guid.Parse("d2916e47-83ac-4f52-b719-05e4c9a2f638"),
                Name = "Laptop",
                Description = "For programming, studying and gaming"
            },
            new ()
            {
                Id = Guid.Parse("6c48b2f9-e157-43a6-8d21-f90b735c4a82"),
                Name = "Accessory",
                Description = "For example, watch and sock"
            }
            ];

        return categories;
    }

    private IEnumerable<Product> GetProducts()
    {
        List<Product> products = [

            new()
            {
                Id = Guid.Parse("b4e72c19-6f35-4a81-9d27-58c3e1f60492"),
                Name = "Samsung Mobile",
                Description = "RAM 6GB, Memory 128GB",
                Price = 20000,
                CategoryId = Guid.Parse("a7f3c821-4b92-4d16-9e35-72c8f1a604b9"),
                Quantity = 10,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new ()
            {
                Id = Guid.Parse("e8315a47-2c69-4f03-b728-91d6c5a84013"),
                Name = "Lenovo Laptop",
                Description = "RAM 16GB, Memory 1TB",
                Price = 10000,
                CategoryId = Guid.Parse("d2916e47-83ac-4f52-b719-05e4c9a2f638"),
                Quantity = 30,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new ()
            {
                Id = Guid.Parse("5d29f816-73b4-4c62-ae05-38f1b927640c"),
                Name = "X-200 Sport Watch",
                Description = "AMOLED, GPS",
                Price = 30000,
                CategoryId = Guid.Parse("6c48b2f9-e157-43a6-8d21-f90b735c4a82"),
                Quantity = 20,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
            ];
        return products;
    }

    private IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = [
            new()
            {
                Id="0af2138d-b32e-4f83-b6cd-3c162a3f6a0e",
                Email="owner@gmail.com",
                UserName="owner@gmail.com",
                PasswordHash="AQAAAAIAAYagAAAAENpoTL/wfsi6Nc5z+yKJinQLIqX2/yCKgek5hJtJv1l++zT2RsorkUVU+bZ+Oj5iYg==",
            },
            new()
            {
                Id="413da784-ecab-4248-b786-d5c6214b9786",
                Email="user@gmail.com",
                UserName="user@gmail.com",
                PasswordHash="AQAAAAIAAYagAAAAEHNi4ANzt2MfxyGlv8LxeTjQspQ0x3k1IpqV99sE1sKzyYrT1GFQCQV9UOGuCMGABA==",
            },
            new()
            {
                Id="f875a48f-21b6-4ff2-8d42-bddabb8244f5",
                Email="admin@gmail.com",
                UserName="admin@gmail.com",
                PasswordHash="AQAAAAIAAYagAAAAEIU1Szp0E/AjYLD12A4cXVgHTcwIby+2C/CNEC+CCkAuLBzuQshqZScLuHMEN5tl5g=="
            }
            ];
        return users;
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        IEnumerable<IdentityRole> roles = [
            new(UserRoles.Admin),
            new(UserRoles.User),
            new(UserRoles.Owner)
            ];
        return roles;
    }
}
