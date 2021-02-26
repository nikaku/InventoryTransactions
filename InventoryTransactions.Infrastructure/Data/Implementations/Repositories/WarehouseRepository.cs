using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Core.Entities.Warehouse;
using InventoryTransactions.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace InventoryTransactions.Infrastructure.Data.Implementations.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DataContext context) : base(context)
        {
             
        }

        private DataContext WarehouseContext => Context as DataContext;
    }
}
