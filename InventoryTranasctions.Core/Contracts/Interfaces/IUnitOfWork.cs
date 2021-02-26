using System.Threading.Tasks;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;

namespace InventoryTransactions.Core.Contracts.Interfaces
{

    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
        IItemRepository ItemRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }
    }

}
