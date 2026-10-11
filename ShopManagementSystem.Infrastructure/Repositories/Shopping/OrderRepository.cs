using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Repositories.Shopping;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories.Shopping;

internal class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    public async Task<Guid> CreateAsync(Order entity)
    {
        await dbContext.Orders.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(string userId)
    {
        List<Order> orders = await dbContext.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return orders;
    }

    public async Task<Order?> GetByIdAsync(string userId, Guid orderId)
    {
        Order? order = await dbContext.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .FirstOrDefaultAsync(o => o.UserId == userId && o.Id == orderId);

        return order;
    }
}
