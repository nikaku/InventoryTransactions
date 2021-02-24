using InventoryTransactions.Core.Entities.Warehouse;
using InventoryTransactions.Domain.Entities.Item;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }
    }
}
