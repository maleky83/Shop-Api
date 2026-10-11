using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Exceptions;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Carts.Commands.DeleteCart;

public class DeleteCartCommandHandler(
    ILogger<DeleteCartCommandHandler> logger,
    ICartRepository cartRepository
    ) : IRequestHandler<DeleteCartCommand>
{
    public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting cart user {UserId}", request.UserId);

        Cart? cart = await cartRepository.GetByUserIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(Cart), request.UserId.ToString());

        await cartRepository.DeleteAsync(cart);
    }
}
