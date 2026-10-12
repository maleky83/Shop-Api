using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities.Carts;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories.Shopping;

namespace Shop.Application.Carts.Commands.DeleteCart;

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
