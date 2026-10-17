using Shop.Application.CartItems.Dtos;

namespace Shop.Application.Carts.Dtos;

public class CartDto
{
    public int CartId { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public IEnumerable<CartItemDto> CartItems { get; set; } = default!;
    public decimal TotalPrice { get; set; }
}
