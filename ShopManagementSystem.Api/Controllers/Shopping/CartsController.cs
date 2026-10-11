using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Application.Carts.Commands.DeleteCart;
using ShopManagementSystem.Application.Carts.Dtos;
using ShopManagementSystem.Application.Carts.Queries.GetCartById;

namespace ShopManagementSystem.Api.Controllers.Shopping;

[ApiController]
[Route("api/carts")]
public class CartsController(IMediator mediator) : ControllerBase
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

    [HttpGet]
    public async Task<ActionResult<CartDto>> GetCart()
    {
        var userId = GetUserId();

        CartDto? cart = await mediator.Send(new GetCartByIdQuery(userId));

        return Ok(cart);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCart()
    {
        var userId = GetUserId();

        await mediator.Send(new DeleteCartCommand(userId));

        return NoContent();
    }
}
