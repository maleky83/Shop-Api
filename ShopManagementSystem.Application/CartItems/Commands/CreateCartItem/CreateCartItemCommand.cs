using MediatR;

namespace ShopManagementSystem.Application.CartItems.Commands.CreateCartItem;

public class CreateCartItemCommand : IRequest<bool>
{
    public string UserId { get; set; } = default!;
    public Guid ProductId { get; set; } = default!;
    public int Quantity { get; set; } = default!;
}
