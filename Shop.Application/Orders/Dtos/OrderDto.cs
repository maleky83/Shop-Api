using Shop.Domain.Enums;

namespace Shop.Application.Orders.Dtos;

public sealed record OrdersCollectionDto
{
    public required IReadOnlyCollection<OrderDto> Data { get; init; }
}

public record OrderDto
{
    public required int OrderId { get; init; }
    public required string UserId { get; init; }
    public decimal TotalPrice { get; init; }
    public OrderStatus OrderStatus { get; init; }
    public List<OrderDetailDto> OrderDetails { get; init; } = default!;
}
