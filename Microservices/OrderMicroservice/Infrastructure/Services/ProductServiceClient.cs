using System.Net.Http.Json;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Application.Orders.Dtos;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ProductServiceClient : IProductServiceClient
    {
        private readonly HttpClient _http;

        public ProductServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            
            var resp = await _http.GetAsync($"/api/Products/{productId}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<ProductDto>()
                   ?? throw new Exception("Product deserialization failed");
        }

        public async Task<bool> UpdateProductStockAsync(int productId, int newStock)
        {
            
            var payload = new { Id = productId, Stock = newStock };

            
            var resp = await _http.PutAsJsonAsync($"/api/Products/{productId}", payload);
            return resp.IsSuccessStatusCode;
        }
    }
}
