using MediatR;
using Shop.Domain.Enums;

namespace Shop.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public string UserId { get; init; }
    public OrderStatus Status { get; init; } = OrderStatus.Pending;
    public decimal TotalPrice { get; init; }
}
