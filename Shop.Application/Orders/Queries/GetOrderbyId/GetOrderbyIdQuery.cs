using MediatR;
using Shop.Application.Orders.Dtos;

namespace Shop.Application.Orders.Queries.GetOrderbyId;

public class GetOrderbyIdQuery(string userId, Guid orderId) : IRequest<OrderDto>
{
    public string UserId { get; } = userId;
    public Guid OrderId { get; } = orderId;
}
