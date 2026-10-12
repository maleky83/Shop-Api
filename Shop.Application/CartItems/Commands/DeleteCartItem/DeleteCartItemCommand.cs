using MediatR;

namespace Shop.Application.CartItems.Commands.DeleteCartItem;

public class DeleteCartItemCommand(string userId, Guid cartItemId) : IRequest
{
    public string UserId { get; set; } = userId;
    public Guid CartItemId { get; set; } = cartItemId;
}
