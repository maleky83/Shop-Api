using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Catalog;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories;

internal class ProductRepository(ShopDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        IEnumerable<Product> products = await dbContext.Products.ToListAsync();

        return products;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        return product;
    }

    public async Task DeleteAsync(Product entity)
    {
        dbContext.Products.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<int> CreateAsync(Product entity)
    {
        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
