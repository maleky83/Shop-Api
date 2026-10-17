using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Carts;
using Shop.Domain.Entities.Orders;

namespace Shop.Domain.Entities.Catalog;

public sealed class Product
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;
    public int CategoryId { get; set; } = default!;


    #region Relations

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; }
        = new List<OrderDetail>();

    public ICollection<CartItem> CartItems { get; }
        = new List<CartItem>();

    #endregion
}
