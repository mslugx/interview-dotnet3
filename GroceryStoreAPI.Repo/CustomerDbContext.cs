using GroceryStoreAPI.Domain.Models.BackendModels;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreAPI.Repository
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
