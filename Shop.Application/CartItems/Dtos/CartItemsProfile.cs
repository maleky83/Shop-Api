using AutoMapper;
using Shop.Application.CartItems.Commands.CreateCartItem;
using Shop.Domain.Entities.Carts;

namespace Shop.Application.CartItems.Dtos;

public class CartItemsProfile : Profile
{
    public CartItemsProfile()
    {
        CreateMap<CreateCartItemCommand, CartItem>();
    }
}
