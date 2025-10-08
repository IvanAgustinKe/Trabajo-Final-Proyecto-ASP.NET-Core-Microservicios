using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Application.Interfaces;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.AsNoTracking().ToListAsync();

        public async Task<Product?> GetByIdAsync(int id)
            => await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity is null) return;
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
