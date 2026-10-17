namespace Shop.Application.Orders.Dtos;

public sealed record OrderDetailDto
{
    public required int OrderDetailId { get; init; }
    public required int OrderId { get; init; }
    public required int ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
