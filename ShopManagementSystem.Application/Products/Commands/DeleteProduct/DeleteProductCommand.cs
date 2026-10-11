using MediatR;

namespace ShopManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
