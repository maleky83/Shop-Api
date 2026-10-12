using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Carts;
using Shop.Domain.Entities.Catalog;
using Shop.Domain.Entities.Orders;

namespace Shop.Infrastructure.Persistence;

internal class ShopDbContext(DbContextOptions<ShopDbContext> options) :
    IdentityDbContext<User>(options)
{
    #region Product

    internal DbSet<OrderDetail> OrderDetail { get; set; }
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<Cart> Carts { get; set; }
    internal DbSet<CartItem> CartItems { get; set; }
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Category> Categories { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);

    }
}
