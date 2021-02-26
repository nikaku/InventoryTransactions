using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Queries;
using InventoryTransactions.Domain.Entities.Item;

namespace InventoryTransactions.Application.Interfaces
{
    public interface IItemService
    {
        Item GetItem(int id);
        IEnumerable<Item> GetItems(GetItemsQuery itemQuery);
        Item AddItem(Item item);
    }
}
