using MediatR;

namespace ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemCommand(string userId, Guid cartItemId) : IRequest
{
    public string UserId { get; set; } = userId;
    public Guid CartItemId { get; set; } = cartItemId;
    public int Quantity { get; init; }
}
