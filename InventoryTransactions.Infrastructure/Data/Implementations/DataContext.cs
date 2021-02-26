using InventoryTransactions.Domain.Entities.Item;
using InventoryTransactions.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace InventoryTransactions.Infrastructure.Data.Implementations
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<WarehouseTransaction> WarehouseTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GoodsIssueRequestVendors>()
            //    .HasOne(p => p.GoodsIssueRequest)
            //    .WithMany(pe => pe.GoodsIssueRequestVendors)
            //    .HasForeignKey(m => m.GoodsIssueRequestId);
        }
    }
}
