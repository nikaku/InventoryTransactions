using System.Collections.Generic;
using System.Linq;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;

namespace InventoryTransactions.Infrastructure.Data.Implementations.Repositories
{
    public class WarehousetransactionRepository : Repository<WarehouseTransaction>, IWarehouseTransactionRepository
    {
        public WarehousetransactionRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<WarehouseTransaction> GetTransactions(int itemId, int warehouseId)
        {
            return WarehouseTransactionContext.WarehouseTransactions.Where(x =>
                 x.ItemId == itemId && x.WarehouseId == warehouseId);
        }

        public int GetCumulativeQuantity(int itemId)
        {
            return WarehouseTransactionContext.WarehouseTransactions.Where(i => i.ItemId == itemId).Sum(w => w.Quantity);
        }

        public int GetCumulativeQuantityOnWarehouse(int itemId, int warehouseId)
        {
            var lastTransactionOnWhs = WarehouseTransactionContext
                    .WarehouseTransactions
                    .OrderBy(x => x.Id)
                    .LastOrDefault(i => i.ItemId == itemId && i.WarehouseId == warehouseId);

            return lastTransactionOnWhs?.CumulativeQuantity ?? 0;
        }

        private DataContext WarehouseTransactionContext => Context as DataContext;
    }
}
