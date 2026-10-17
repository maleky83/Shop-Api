using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Dtos;
using Shop.Application.Orders.Queries.GetAllOrders;
using Shop.Application.Orders.Queries.GetOrderbyId;
using Shop.Application.Users;

namespace Shop.Api.Controllers.Shopping;

[ApiController]
[Route("api/orders")]
public sealed class OrdersController(IMediator mediator, IUserContext userContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        var user = userContext.GetCurrentUser();

        IEnumerable<OrderDto> orderDtos = await mediator.Send(new GetAllOrdersQuery(user!.Id));

        return Ok(orderDtos);
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
    {
        var user = userContext.GetCurrentUser();

        OrderDto order = await mediator.Send(new GetOrderbyIdQuery(user!.Id, orderId));

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderCommand command)
    {
        var user = userContext.GetCurrentUser();

        int id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetOrder), new { id });
    }
}
