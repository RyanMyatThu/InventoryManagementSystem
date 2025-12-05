using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EfCore
{
    public class IMSDbContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPrice> CustomerPrices { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Vouchers> Vouchers { get; set; }

        
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


            modelBuilder.Entity<Vouchers>()
                .HasOne(v => v.Report)
                .WithMany(rp => rp.Vouchers)
                .HasForeignKey(v => v.ReportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vouchers>()
                .HasOne(v => v.Inventory)
                .WithMany(i => i.Vouchers)
                .HasForeignKey(v => v.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reports>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);






          
            
               
        }

    }
}
