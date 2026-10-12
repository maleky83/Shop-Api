using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.Dtos;
using Shop.Domain.Entities.Catalog;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(
    ILogger<GetAllProductsQueryHandler> logger,
    IProductRepository productRepository,
    IMapper mapper
    ) :
    IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all products {@Products}", request);

        IEnumerable<Product> products = await productRepository.GetAllAsync();

        IEnumerable<ProductDto> productDtos = mapper.Map<IEnumerable<ProductDto>>(products);

        return productDtos;
    }
}
