using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities.Carts;
using Shop.Domain.Entities.Orders;

namespace Shop.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly DateOfBirth { get; set; }
    public string? Nationality { get; set; }

    public bool IsActive { get; set; } = true;

    #region Relations

    public Cart Cart { get; set; } = default!;

    public ICollection<Order> Orders { get; set; } = [];

    #endregion
}
