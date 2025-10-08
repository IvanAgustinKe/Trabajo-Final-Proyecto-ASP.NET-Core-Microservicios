using OrderMicroservice.Domain.ValueObjects;

namespace OrderMicroservice.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public decimal Total => _items.Sum(i => i.Subtotal);

       
        private Order() { }

        public Order(int customerId, IEnumerable<OrderItem> items)
        {
            CustomerId = customerId;
            _items = items.ToList();
            if (!_items.Any())
                throw new ArgumentException("Order must contain at least one item");
        }

       
        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
