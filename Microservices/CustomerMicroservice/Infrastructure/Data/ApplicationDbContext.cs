using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Domain.Entities;

namespace CustomerMicroservice.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
