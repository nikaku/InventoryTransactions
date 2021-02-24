using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Item;

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

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll();
        }

        public Item AddItem(Item item)
        {
            var itemInDb =  _itemRepository.Add(item);
            _unitOfWork.SaveChanges();
            return itemInDb;
        }
    }
}
