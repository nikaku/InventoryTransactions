using InventoryTransactions.Application.Commands.WarehouseTransactions;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;
using System;
using System.Collections.Generic;

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
            return _warehouseTransactionRepository.Get(id);
        }

        public IEnumerable<WarehouseTransaction> GetTransactions(int itemId, int warehouseId)
        {
            return _warehouseTransactionRepository.FindAll(x => x.ItemId == itemId && x.WarehouseId == warehouseId);
        }

        public int GetCumulativeQuantity(int itemId)
        {
            return _warehouseTransactionRepository.GetCumulativeQuantity(itemId);
        }

        public int GetCumulativeQuantityOnWarehouse(int itemId, int warehouseId)
        {
            return _warehouseTransactionRepository.GetCumulativeQuantityOnWarehouse(itemId, warehouseId);
        }

        public void Issue(CreateIssueCommand issueCommand)
        {
            int cumulativeQuantity;

            if (issueCommand.WarehouseId == 0)
            {
                cumulativeQuantity = _warehouseTransactionRepository.GetCumulativeQuantity(issueCommand.ItemId);
            }
            else
            {
                cumulativeQuantity =
                    _warehouseTransactionRepository.GetCumulativeQuantityOnWarehouse(issueCommand.ItemId,
                        issueCommand.WarehouseId);
            }

            if (cumulativeQuantity + issueCommand.Quantity < 0)
            {
                throw new InvalidOperationException("Quantity Falls Into Negative Quantity");
            }

            cumulativeQuantity = cumulativeQuantity += issueCommand.Quantity;

            _warehouseTransactionRepository.Add(new WarehouseTransaction
            {
                Comment = issueCommand.Comment,
                WarehouseId = issueCommand.WarehouseId,
                ItemId = issueCommand.ItemId,
                CreateDate = DateTime.UtcNow.AddHours(4),
                CumulativeQuantity = cumulativeQuantity,
                Quantity = issueCommand.Quantity,
                PostingDate = issueCommand.PostingDate
            });
        }

        public void Receipt(CreateReceiptCommand receiptCommand)
        {
            _warehouseTransactionRepository.Add(
               new WarehouseTransaction
               {
                   WarehouseId = receiptCommand.WarehouseId,
                   Comment = receiptCommand.Comment,
                   CreateDate = DateTime.UtcNow.AddHours(4),
                   ItemId = receiptCommand.ItemId,
                   PostingDate = receiptCommand.PostingDate,
                   Quantity = receiptCommand.Quantity,
                   CumulativeQuantity = _warehouseTransactionRepository.GetCumulativeQuantity(
                       GetCumulativeQuantityOnWarehouse(receiptCommand.ItemId, receiptCommand.WarehouseId))
               });
        }
    }
}
