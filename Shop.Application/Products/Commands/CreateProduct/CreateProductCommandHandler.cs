using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities.Catalog;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IMapper mapper,
    ILogger<CreateProductCommandHandler> logger,
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IValidator<CreateProductCommand> validator
    ) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating product {Product}", request);

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        Category? category = await categoryRepository.GetByIdAsync(request.CategoryId)
            ?? throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

        Product product = mapper.Map<Product>(request);

        return await productRepository.CreateAsync(product);
    }
}
