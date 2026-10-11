using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Domain.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task DeleteAsync(string id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(string id);
    Task<User> GetUserByNameAsync(string name);
    Task UpdateAsync(string id, User entity);
}
