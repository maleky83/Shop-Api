using Shop.Domain.Entities.Catalog;

namespace Shop.Domain.Repositories;

public interface IProductRepository
{
    Task<int> CreateAsync(Product entity);
    Task DeleteAsync(Product entity);
    public Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task SaveChangesAsync();
}
