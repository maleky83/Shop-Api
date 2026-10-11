using MediatR;
using ShopManagementSystem.Application.Orders.Dtos;

namespace ShopManagementSystem.Application.Orders.Queries.GetAllOrders;

public class GetAllOrdersQuery(string userId) : IRequest<IEnumerable<OrderDto>>
{
    public string UserId { get; } = userId;
}
