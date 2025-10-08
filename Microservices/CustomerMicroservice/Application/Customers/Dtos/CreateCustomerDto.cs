namespace CustomerMicroservice.Application.Customers.Dtos
{
    public class CreateCustomerDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
