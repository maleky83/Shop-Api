using Shop.Domain.Entities.Carts;

namespace Shop.Domain.Repositories.Shopping;

public interface ICartRepository
{
    Task DeleteAsync(Cart entity);
    Task<Cart?> GetByUserIdAsync(string userId);
}
