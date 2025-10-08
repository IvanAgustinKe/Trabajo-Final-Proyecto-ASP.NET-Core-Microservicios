using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = null!;
    }
}
