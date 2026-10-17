using MediatR;

namespace Shop.Application.CartItems.Commands.CreateCartItem;

public class CreateCartItemCommand : IRequest
{
    public string UserId { get; set; } = default!;
    public int ProductId { get; set; } = default!;
    public int Quantity { get; set; } = default!;
}
