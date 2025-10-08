namespace OrderMicroservice.Domain.ValueObjects
{
    public class OrderItem
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; } = null!;
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal Subtotal => UnitPrice * Quantity;

       
        private OrderItem() { }

        public OrderItem(int productId, string name, decimal unitPrice, int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be > 0");
            ProductId = productId;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
