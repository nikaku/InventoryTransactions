using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Item;

namespace InventoryTransactions.Domain.Contracts.Interfaces.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
    }
}
