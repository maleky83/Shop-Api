using MediatR;

namespace Shop.Application.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemCommand(string userId, int cartItemId) : IRequest
{
    public string UserId { get; set; } = userId;
    public int CartItemId { get; set; } = cartItemId;
    public int Quantity { get; init; }
}
