using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EfCore
{
    public class IMSDbContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPrice> CustomerPrices { get; set; }
        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPrice>()
             .HasIndex(cp => new { cp.CustomerId, cp.InventoryId })
             .IsUnique();

            modelBuilder.Entity<CustomerPrice>()
              .HasOne(cp => cp.Customer)
              .WithMany(c => c.CustomerPrices)
              .HasForeignKey(cp => cp.CustomerId);

            modelBuilder.Entity<CustomerPrice>()
              .HasOne(cp => cp.Inventory)
              .WithMany(i => i.CustomerPrices)
              .HasForeignKey(cp => cp.InventoryId);

        }

    }
}
