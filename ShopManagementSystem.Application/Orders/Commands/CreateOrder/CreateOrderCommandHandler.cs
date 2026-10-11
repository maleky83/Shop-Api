using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Domain.Enums;
using ShopManagementSystem.Domain.Exceptions;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(
    ILogger<CreateOrderCommandHandler> logger,
    IValidator<CreateOrderCommand> validator,
    IOrderRepository orderRepository,
    ICartRepository cartRepository
    ) : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        logger.LogInformation("Creating order for user {UserId}", request.UserId);

        Cart? cart = await cartRepository.GetByUserIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(Cart), request.UserId.ToString());

        var order = new Order
        {
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending,
        };

        foreach (CartItem cartItem in cart.CartItems)
        {
            var orderDetail = new OrderDetail
            {
                UnitPrice = cartItem.Product.Price,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.Quantity * cartItem.Product.Price,
            };

            order.OrderDetails.Add(orderDetail);
        }

        order.TotalPrice = order.OrderDetails.Sum(od => od.TotalPrice);

        return await orderRepository.CreateAsync(order);
    }
}
