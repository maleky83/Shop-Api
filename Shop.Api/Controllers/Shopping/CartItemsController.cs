using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.CartItems.Commands.CreateCartItem;
using Shop.Application.CartItems.Commands.DeleteCartItem;
using Shop.Application.CartItems.Commands.UpdateCartItem;

namespace Shop.Api.Controllers.Shopping;

[ApiController]
[Route("api/cartItems")]
public sealed class CartItemsController(
    IMediator mediator
    ) : ControllerBase
{
    private string GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new UnauthorizedAccessException("Invalid user");
        }

        return userId;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateCartItem(
        [FromBody] CreateCartItemCommand command)
    {
        var userId = GetUserId();

        command.UserId = userId;

        await mediator.Send(command);

        return Created();
    }

    [HttpPatch("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateCartItem(
       [FromRoute] Guid cartItemId,
       [FromBody] UpdateCartItemCommand command)
    {
        var userId = GetUserId();

        command.UserId = userId;
        command.CartItemId = cartItemId;

        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCartItem(
        [FromRoute] Guid cartItemId,
        [FromBody] DeleteCartItemCommand command)
    {
        var userId = GetUserId();

        command.UserId = userId;
        command.CartItemId = cartItemId;

        await mediator.Send(command);

        return NoContent();
    }
}
