using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Commands.WarehouseTransactions;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;

namespace InventoryTransactions.Application.Services
{
    public class WarehouseTransactionService : IWarehouseTransactionService
    {
        private readonly IWarehouseTransactionRepository _warehouseTransactionRepository;

        public WarehouseTransactionService(IWarehouseTransactionRepository warehouseTransactionRepository)
        {
            _warehouseTransactionRepository = warehouseTransactionRepository;
        }

        public WarehouseTransaction GetTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseTransaction> GetTransactions(int itemId, int warehouseId)
        {
            throw new NotImplementedException();
        }

        public int GetCumulativeQuantity(int itemId)
        {
            throw new NotImplementedException();
        }

        public int GetCumulativeQuantityOnWarehouse(int itemId, int warehouseId)
        {
            throw new NotImplementedException();
        }

        public void Issue(CreateIssueCommand issueCommand)
        {
            throw new NotImplementedException();
        }

        public void Receipt(CreateReceiptCommand receiptCommand)
        {
            throw new NotImplementedException();
        }
    }
}
