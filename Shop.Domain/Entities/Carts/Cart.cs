using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities.Carts;

public sealed class Cart
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = default!;

    #region Relations

    public ICollection<CartItem> CartItems { get; set; } = [];

    #endregion
}
