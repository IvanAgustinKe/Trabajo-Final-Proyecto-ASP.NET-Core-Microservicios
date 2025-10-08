using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Application.Interfaces;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _ctx;
        public OrderRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<Order> AddAsync(Order order)
        {
            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _ctx.Orders
                .Include(o => o.Items)
                .ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _ctx.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
    }
}
