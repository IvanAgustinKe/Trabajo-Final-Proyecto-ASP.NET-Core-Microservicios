using OrderMicroservice.Application.Interfaces;

namespace OrderMicroservice.Infrastructure.Services
{
    public class CustomerServiceClient : ICustomerServiceClient
    {
        private readonly HttpClient _http;
        public CustomerServiceClient(HttpClient http) => _http = http;

        public async Task<bool> CustomerExistsAsync(int customerId)
        {
            var resp = await _http.GetAsync($"/api/Customers/{customerId}");
            return resp.IsSuccessStatusCode;
        }
    }
}
