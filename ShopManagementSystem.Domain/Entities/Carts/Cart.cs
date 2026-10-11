namespace ShopManagementSystem.Domain.Entities.Carts;

public sealed class Cart
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; } = default!;

    public User User { get; set; } = null!;

    #region Relations

    public ICollection<CartItem> CartItems { get; set; } = null!;

    #endregion
}
