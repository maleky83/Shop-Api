using MediatR;
using Shop.Application.Products.Dtos;

namespace Shop.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery(Guid id) : IRequest<ProductDto>
{
    public Guid Id { get; } = id;
}
