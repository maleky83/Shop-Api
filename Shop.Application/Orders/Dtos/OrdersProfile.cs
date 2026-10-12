using AutoMapper;
using Shop.Domain.Entities.Orders;

namespace Shop.Application.Orders.Dtos;

internal class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(
            dest => dest.OrderId,
            opt => opt.MapFrom(src => src.Id));
    }
}
