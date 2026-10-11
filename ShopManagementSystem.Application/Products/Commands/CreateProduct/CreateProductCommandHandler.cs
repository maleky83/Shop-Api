using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Exceptions;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IMapper mapper,
    ILogger<CreateProductCommandHandler> logger,
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IValidator<CreateProductCommand> validator
    ) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(
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
