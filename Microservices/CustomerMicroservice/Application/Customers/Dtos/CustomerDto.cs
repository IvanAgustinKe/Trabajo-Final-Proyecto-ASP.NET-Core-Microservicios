namespace CustomerMicroservice.Application.Customers.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime RegisteredAt { get; set; }
    }
}
