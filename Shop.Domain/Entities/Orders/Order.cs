using Shop.Domain.Enums;

namespace Shop.Domain.Entities.Orders;

public sealed class Order
{
    public int Id { get; set; } 
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; } = default!;

    public User User { get; set; } = null!;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalPrice { get; set; }

    #region Relations
    public ICollection<OrderDetail> OrderDetails { get; } = default!;
    #endregion
}
