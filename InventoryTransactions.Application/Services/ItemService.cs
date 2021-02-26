using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Application.Queries;
using InventoryTransactions.Core.Contracts.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Item;
using System.Collections.Generic;
using InventoryTransactions.Application.Queries.Item;
using InventoryTransactions.Domain.Contracts.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;

namespace InventoryTransactions.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }
        public Item GetItem(int id)
        {
            return _itemRepository.Get(id);
        }

        public IEnumerable<Item> GetItems(GetItemsQuery itemQuery)
        {
            return _itemRepository.FindAll(x =>
                (x.Brand == itemQuery.Brand || itemQuery.Brand == null) &&
                (x.Description == itemQuery.Description || itemQuery.Description == null) &&
                (x.SerialNumber == itemQuery.SerialNumber || itemQuery.SerialNumber == null) &&
                (x.Name == itemQuery.Name || itemQuery.Name == null) &&
                (x.Id == itemQuery.Id || itemQuery.Id == 0)
            );
        }

        public Item AddItem(Item item)
        {
            var itemInDb = _itemRepository.Add(item);
            _unitOfWork.SaveChanges();
            return itemInDb;
        }
    }
}
