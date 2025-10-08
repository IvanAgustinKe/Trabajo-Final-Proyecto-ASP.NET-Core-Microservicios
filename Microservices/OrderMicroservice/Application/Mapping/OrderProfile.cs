using AutoMapper;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.ValueObjects;
using OrderMicroservice.Application.Orders.Dtos;

namespace OrderMicroservice.Application.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<CreateOrderItemDto, OrderItem>();
        }
    }
}
