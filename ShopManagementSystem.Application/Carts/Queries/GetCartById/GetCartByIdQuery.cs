using MediatR;
using ShopManagementSystem.Application.Carts.Dtos;

namespace ShopManagementSystem.Application.Carts.Queries.GetCartById;

public class GetCartByIdQuery(string userId) : IRequest<CartDto>
{
    public string UserId { get; } = userId;
}
