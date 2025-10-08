namespace OrderMicroservice.Application.Orders.Dtos
{
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
