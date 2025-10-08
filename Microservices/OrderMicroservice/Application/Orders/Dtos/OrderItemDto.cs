namespace OrderMicroservice.Application.Orders.Dtos
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => UnitPrice * Quantity;
    }
}
