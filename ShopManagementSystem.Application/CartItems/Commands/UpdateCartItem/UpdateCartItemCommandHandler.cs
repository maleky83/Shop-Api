using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Exceptions;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemCommandHandler(
    ILogger<UpdateCartItemCommandHandler> logger,
    ICartItemRepository cartItemRepository,
    IValidator<UpdateCartItemCommand> validator
    ) : IRequestHandler<UpdateCartItemCommand>
{
    public async Task Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating cartItem {CartItemId}", request.CartItemId);

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        CartItem? cartItem = await cartItemRepository
            .GetByIdAsync(request.CartItemId)
            ?? throw new NotFoundException(nameof(CartItem), request.CartItemId.ToString());

        cartItem.Quantity = request.Quantity;

        await cartItemRepository.SaveChangesAsync();
    }
}
