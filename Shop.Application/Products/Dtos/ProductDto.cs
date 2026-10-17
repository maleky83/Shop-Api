namespace Shop.Application.Products.Dtos;

public sealed record ProductDto
{
    public required int ProductId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public required int CategoryId { get; init; }
}
