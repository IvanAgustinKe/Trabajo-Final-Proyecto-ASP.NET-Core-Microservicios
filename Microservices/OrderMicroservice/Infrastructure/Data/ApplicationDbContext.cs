using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Domain.Entities;
using OrderMicroservice.Domain.ValueObjects;

namespace OrderMicroservice.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(o => o.Id);

               
                e.OwnsMany(o => o.Items, b =>
                {
                    b.WithOwner().HasForeignKey("OrderId");
                    b.Property<int>("Id");       
                    b.HasKey("Id");
                    b.ToTable("OrderItems");     
                });
            });
        }
    }
}
