using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Application.Interfaces;
using CustomerMicroservice.Domain.Entities;
using CustomerMicroservice.Infrastructure.Data;

namespace CustomerMicroservice.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CustomerRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _ctx.Customers.AsNoTracking().ToListAsync();

        public async Task<Customer?> GetByIdAsync(int id) =>
            await _ctx.Customers.FindAsync(id);

        public async Task AddAsync(Customer customer)
        {
            await _ctx.Customers.AddAsync(customer);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _ctx.Customers.Update(customer);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _ctx.Customers.FindAsync(id);
            if (c is null) return;
            _ctx.Customers.Remove(c);
            await _ctx.SaveChangesAsync();
        }
    }
}
