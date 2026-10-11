using MediatR;
using ShopManagementSystem.Application.Orders.Dtos;

namespace ShopManagementSystem.Application.Orders.Queries.GetOrderbyId;

public class GetOrderbyIdQuery(string userId, Guid orderId) : IRequest<OrderDto>
{
    public string UserId { get; } = userId;
    public Guid OrderId { get; } = orderId;
}
