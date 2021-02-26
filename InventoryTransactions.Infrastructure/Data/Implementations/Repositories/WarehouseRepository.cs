using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;

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
