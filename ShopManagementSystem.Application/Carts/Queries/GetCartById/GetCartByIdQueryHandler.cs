using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopManagementSystem.Application.Carts.Dtos;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Exceptions;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Carts.Queries.GetCartById;

public class GetCartByIdQueryHandler(
    ILogger<GetCartByIdQueryHandler> logger,
    ICartRepository cartRepository,
    IMapper mapper
    ) : IRequestHandler<GetCartByIdQuery, CartDto>
{
    public async Task<CartDto> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get cart by user {UserId}", request.UserId);

        Cart? cart = await cartRepository.GetByUserIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(Cart), request.UserId.ToString());

        CartDto cartDto = mapper.Map<CartDto>(cart);
        return cartDto;
    }
}
