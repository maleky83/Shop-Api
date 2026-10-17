using Shop.Domain.Entities.Catalog;

namespace Shop.Domain.Entities.Carts;

public class CartItem
{
    public int Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public int CartId { get; set; } = default!;

    public Cart Cart { get; set; } = null!;

    public int ProductId { get; set; } = default!;

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
