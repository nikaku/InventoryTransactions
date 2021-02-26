using System.Collections.Generic;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;

namespace InventoryTransactions.Domain.Contracts.Interfaces.Repositories
{
    public interface IWarehouseTransactionRepository : IRepository<WarehouseTransaction>
    {
        IEnumerable<WarehouseTransaction> GetTransactions(int itemId, int warehouseId);
        int GetCumulativeQuantity(int itemId);
        int GetCumulativeQuantityOnWarehouse(int itemId, int warehouseId);
    }
}
