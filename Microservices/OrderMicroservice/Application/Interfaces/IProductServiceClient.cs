using OrderMicroservice.Application.Orders.Dtos;

namespace OrderMicroservice.Application.Interfaces
{
    public interface IProductServiceClient
    {
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<bool> UpdateProductStockAsync(int productId, int newStock);
    }
}
