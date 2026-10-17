using Shop.Domain.Entities.Orders;

namespace Shop.Domain.Repositories.Shopping;

public interface IOrderRepository
{
    Task<int> CreateAsync(Order entity);
    Task<IEnumerable<Order>> GetAllAsync(string userId);
    Task<Order?> GetByIdAsync(string userId, int orderId);
}
