using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using System.Threading.Tasks;

namespace InventoryTransactions.Domain.Contracts.Interfaces
{

    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
        IItemRepository ItemRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }
        IWarehouseTransactionRepository WarehouseTransactionRepository { get; }
    }

}
