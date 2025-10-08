using MediatR;
using OrderMicroservice.Application.Orders.Dtos;
using System.Collections.Generic;

namespace OrderMicroservice.Application.Orders.Queries
{
    public record GetAllOrdersQuery() : IRequest<IEnumerable<OrderDto>>;
}
