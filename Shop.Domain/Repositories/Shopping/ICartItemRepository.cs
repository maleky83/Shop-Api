using Shop.Domain.Entities.Carts;

namespace Shop.Domain.Repositories.Shopping;

public interface ICartItemRepository
{
    Task AddAsync(string userId, CartItem entity);
    Task DeleteAsync(CartItem entity);
    Task<IEnumerable<CartItem>> GetAllByCartIdAsync(Guid cartId);
    Task<CartItem?> GetByIdAsync(Guid cartItemId);
    Task SaveChangesAsync();
}
