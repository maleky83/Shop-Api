using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Dtos;
using Shop.Application.Orders.Queries.GetAllOrders;
using Shop.Application.Orders.Queries.GetOrderbyId;

namespace Shop.Api.Controllers.Shopping;

[ApiController]
[Route("api/orders")]
public sealed class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        var userId = GetUserId();

        IEnumerable<OrderDto> orderDtos = await mediator.Send(new GetAllOrdersQuery(userId));

        return Ok(orderDtos);
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetOrder(Guid orderId)
    {
        var userId = GetUserId();

        OrderDto order = await mediator.Send(new GetOrderbyIdQuery(userId, orderId));

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderCommand command)
    {
        var userId = GetUserId();

        Guid id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetOrder), new { id });
    }

    private string GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new UnauthorizedAccessException("Invalid user");
        }

        return userId;
    }
}
