using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.CartItems.Commands.CreateCartItem;
using ShopManagementSystem.Application.CartItems.Commands.DeleteCartItem;
using ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

namespace ShopManagementSystem.Api.Controllers.Shopping;

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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateCartItem(
        [FromBody] CreateCartItemCommand command)
    {
        var userId = GetUserId();

        command.UserId = userId;

        var isCreated = await mediator.Send(command);

        if (isCreated)
            return Created();

        return NotFound();
    }

    [HttpPatch("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
