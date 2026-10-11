using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Domain.Entities;

public class User : IdentityUser
{
    //public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; }
    //public required string Name { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    #region Relations

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public Cart? Cart { get; set; }

    public ICollection<Orders.Order> Orders { get; }
        = new List<Orders.Order>();

    #endregion
}
