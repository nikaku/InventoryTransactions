using System.Collections.Generic;
using InventoryTransactions.Application.Commands.WarehouseTransactions;
using InventoryTransactions.Domain.Entities.Warehouse;

namespace InventoryTransactions.Application.Interfaces
{
    public interface IWarehouseTransactionService
    {
        WarehouseTransaction GetTransaction(int id);
        IEnumerable<WarehouseTransaction> GetTransactions(int itemId, int warehouseId);
        int GetCumulativeQuantity(int itemId);
        int GetCumulativeQuantityOnWarehouse(int itemId, int warehouseId);
        void Issue(CreateIssueCommand issueCommand);
        void Receipt(CreateRecieptCommand receiptCommand);
    }
}
