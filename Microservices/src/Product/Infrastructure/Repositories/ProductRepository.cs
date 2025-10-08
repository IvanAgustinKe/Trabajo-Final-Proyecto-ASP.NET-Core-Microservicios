using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using Product.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product) =>
            await _context.Products.AddAsync(product);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
                _context.Products.Remove(entity);
        }

        public async Task<Product?> GetByIdAsync(Guid id) =>
            await _context.Products.FindAsync(id);

        public async Task<IReadOnlyList<Product>> ListAsync() =>
            await _context.Products
                          .AsNoTracking()
                          .ToListAsync();

        public Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            return Task.CompletedTask;
        }
    }
}
