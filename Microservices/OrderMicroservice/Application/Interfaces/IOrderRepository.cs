using OrderMicroservice.Domain.Entities;

namespace OrderMicroservice.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
    }
}
