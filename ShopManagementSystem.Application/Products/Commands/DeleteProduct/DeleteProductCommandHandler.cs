using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Exceptions;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(
    ILogger<DeleteProductCommandHandler> logger,
    IProductRepository productRepository
    ) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product {ProductId}", request.Id);

        Product? product = await productRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Product), request.Id.ToString());

        await productRepository.DeleteAsync(product);
    }
}
