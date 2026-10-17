using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Catalog;

namespace Shop.Domain.Entities.Orders;

public class OrderDetail
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = default!;

    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = default!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
}
