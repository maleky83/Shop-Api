using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Carts.Dtos;
using Shop.Domain.Entities.Carts;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories.Shopping;

namespace Shop.Application.Carts.Queries.GetCartById;

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
