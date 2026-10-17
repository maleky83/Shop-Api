using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Carts.Commands.DeleteCart;
using Shop.Application.Carts.Dtos;
using Shop.Application.Carts.Queries.GetCartById;
using Shop.Application.Users;

namespace Shop.Api.Controllers.Shopping;

[ApiController]
[Route("api/carts")]
public class CartsController(IMediator mediator, IUserContext userContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CartDto>> GetCart()
    {
        var user = userContext.GetCurrentUser();

        CartDto? cart = await mediator.Send(new GetCartByIdQuery(user!.Id));

        return Ok(cart);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCart()
    {
        var user = userContext.GetCurrentUser();

        await mediator.Send(new DeleteCartCommand(user!.Id));

        return NoContent();
    }
}
