using Shop.Domain.Entities.Catalog;

namespace Shop.Domain.Entities.Orders;

public sealed class OrderDetail
{
    public int Id { get; set; } 
    public DateTime CreatedAt { get; set; }
    public int OrderId { get; set; } 

    public Order Order { get; set; } = null!;

    public required int ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
