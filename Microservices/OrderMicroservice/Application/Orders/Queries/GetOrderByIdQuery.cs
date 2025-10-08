using MediatR;
using OrderMicroservice.Application.Orders.Dtos;

namespace OrderMicroservice.Application.Orders.Queries
{
    public record GetOrderByIdQuery(int Id) : IRequest<OrderDto?>;
}
