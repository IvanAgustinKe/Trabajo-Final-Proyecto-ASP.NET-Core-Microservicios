using System;
using System.Collections.Generic;

namespace OrderMicroservice.Application.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; } = null!;
    }
}
