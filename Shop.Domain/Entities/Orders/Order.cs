using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Enums;

namespace Shop.Domain.Entities.Orders;

public sealed class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = default!;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalPrice { get; set; }

    #region Relations
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    #endregion
}
