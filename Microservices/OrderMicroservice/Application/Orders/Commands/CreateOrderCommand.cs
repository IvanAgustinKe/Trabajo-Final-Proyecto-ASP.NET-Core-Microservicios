using MediatR;
using OrderMicroservice.Application.Orders.Dtos;
using System.Collections.Generic;

namespace OrderMicroservice.Application.Orders.Commands
{
    public record CreateOrderCommand(
        int CustomerId,
        IEnumerable<CreateOrderItemDto> Items
    ) : IRequest<OrderDto>;
}
