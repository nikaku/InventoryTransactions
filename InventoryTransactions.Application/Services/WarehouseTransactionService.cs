using InventoryTransactions.Application.Commands.WarehouseTransactions;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using InventoryTransactions.Domain.Contracts.Interfaces;

namespace InventoryTransactions.Application.Services
{
    public class WarehouseTransactionService : IWarehouseTransactionService
    {
        private readonly IWarehouseTransactionRepository _warehouseTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepository _itemRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseTransactionService(IWarehouseTransactionRepository warehouseTransactionRepository, IUnitOfWork unitOfWork, IItemRepository itemRepository, IWarehouseRepository warehouseRepository)
        {
            _warehouseTransactionRepository = warehouseTransactionRepository;
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
            _warehouseRepository = warehouseRepository;
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

            if (issueCommand.Quantity <= 0)
            {
                //throw new InvalidEnumArgumentException("Quantity Must Be Greater Then 0");
            }

            var item = _itemRepository.Get(issueCommand.ItemId);

            if (issueCommand.ItemId == 0 || item == null)
            {
                throw new InvalidEnumArgumentException("Item Not Exists");
            }

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

            if (cumulativeQuantity - issueCommand.Quantity < 0)
            {
                throw new InvalidOperationException("Quantity Falls Into Negative Quantity");
            }

            var warehouses = _warehouseRepository.GetAll().OrderBy(x => x.Priority);
            foreach (var warehouse in warehouses)
            {
                var qtyOnWhs = _warehouseTransactionRepository.GetCumulativeQuantityOnWarehouse(issueCommand.ItemId, warehouse.Id);

                if (qtyOnWhs == 0)
                {
                    continue;
                }
                var remainder = qtyOnWhs - issueCommand.Quantity;

                if (remainder >= 0)
                {
                    _warehouseTransactionRepository.Add(new WarehouseTransaction
                    {
                        Comment = issueCommand.Comment,
                        WarehouseId = warehouse.Id,
                        ItemId = issueCommand.ItemId,
                        CreateDate = DateTime.UtcNow.AddHours(4),
                        CumulativeQuantity = qtyOnWhs - issueCommand.Quantity,
                        Quantity = -issueCommand.Quantity,
                        PostingDate = issueCommand.PostingDate
                    });

                    break;
                }

                _warehouseTransactionRepository.Add(new WarehouseTransaction
                {
                    Comment = issueCommand.Comment,
                    WarehouseId = warehouse.Id,
                    ItemId = issueCommand.ItemId,
                    CreateDate = DateTime.UtcNow.AddHours(4),
                    CumulativeQuantity = 0,
                    Quantity = -qtyOnWhs,
                    PostingDate = issueCommand.PostingDate
                });

                issueCommand.Quantity = -remainder;
            }

            _unitOfWork.SaveChanges();
        }

        public void Receipt(CreateReceiptCommand receiptCommand)
        {
            if (receiptCommand.Quantity <= 0)
            {
                throw new InvalidEnumArgumentException("Item Must Be Greater Then Zero");
            }

            var item = _itemRepository.Get(receiptCommand.ItemId);

            if (item == null)
            {
                throw new InvalidEnumArgumentException("Item Not Exists");
            }

            var whs = _warehouseRepository.Get(receiptCommand.WarehouseId);

            if (whs == null)
            {
                throw new InvalidEnumArgumentException("Warehouse Not Exists");
            }

            var cumulativeQuantity =
                _warehouseTransactionRepository.GetCumulativeQuantityOnWarehouse(receiptCommand.ItemId,
                    receiptCommand.WarehouseId);

            cumulativeQuantity += receiptCommand.Quantity;


            _warehouseTransactionRepository.Add(
               new WarehouseTransaction
               {
                   WarehouseId = receiptCommand.WarehouseId,
                   Comment = receiptCommand.Comment,
                   CreateDate = DateTime.UtcNow.AddHours(4),
                   ItemId = receiptCommand.ItemId,
                   PostingDate = receiptCommand.PostingDate,
                   Quantity = receiptCommand.Quantity,
                   CumulativeQuantity = cumulativeQuantity
               });

            _unitOfWork.SaveChanges();
        }
    }
}
