using System.Collections.Generic;

namespace OrderMicroservice.Application.Orders.Dtos
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public IEnumerable<CreateOrderItemDto> Items { get; set; } = null!;
    }
}
