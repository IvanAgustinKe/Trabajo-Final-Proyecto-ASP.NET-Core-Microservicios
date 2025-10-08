namespace OrderMicroservice.Application.Interfaces
{
    public interface ICustomerServiceClient
    {
        Task<bool> CustomerExistsAsync(int customerId);
    }
}
