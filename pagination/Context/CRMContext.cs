using Microsoft.EntityFrameworkCore;
using Pagination.Models;

namespace Pagination.Context
{
    public class CRMContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }

        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}