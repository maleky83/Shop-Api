using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Domain.Repositories.Shopping;

public interface IOrderRepository
{
    Task<Guid> CreateAsync(Order entity);
    Task<IEnumerable<Order>> GetAllAsync(string userId);
    Task<Order?> GetByIdAsync(string userId, Guid orderId);
}
