using MediatR;
using Shop.Application.Products.Dtos;

namespace Shop.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}
