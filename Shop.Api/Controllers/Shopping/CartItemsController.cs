using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.CartItems.Commands.CreateCartItem;
using Shop.Application.CartItems.Commands.DeleteCartItem;
using Shop.Application.CartItems.Commands.UpdateCartItem;
using Shop.Application.Users;

namespace Shop.Api.Controllers.Shopping;

[ApiController]
[Route("api/cartItems")]
public sealed class CartItemsController(
    IMediator mediator, IUserContext userContext
    ) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateCartItem(
        [FromBody] CreateCartItemCommand command)
    {
        var user = userContext.GetCurrentUser();

        command.UserId = user!.Id;

        await mediator.Send(command);

        return Created();
    }

    [HttpPatch("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateCartItem(
       [FromRoute] int cartItemId,
       [FromBody] UpdateCartItemCommand command)
    {
        var user = userContext.GetCurrentUser();

        command.UserId = user!.Id;
        command.CartItemId = cartItemId;

        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{cartItemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCartItem(
        [FromRoute] int cartItemId,
        [FromBody] DeleteCartItemCommand command)
    {
        var user = userContext.GetCurrentUser();

        command.UserId = user!.Id;
        command.CartItemId = cartItemId;

        await mediator.Send(command);

        return NoContent();
    }
}
