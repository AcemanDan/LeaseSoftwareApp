using Microsoft.EntityFrameworkCore;
using LeaseSoftware.Models;

namespace LeaseSoftware.Data
{
    public class LeaseSoftwareContext : DbContext
    {
        public LeaseSoftwareContext (DbContextOptions<LeaseSoftwareContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().ToTable("Tenant");
        }
    }
}
