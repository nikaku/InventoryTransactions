using System.Threading.Tasks;
using InventoryTransactions.Core.Contracts.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Contracts.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Infrastructure.Data.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryTransactions.Infrastructure.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            WarehouseRepository = new WarehouseRepository(_dataContext);
            ItemRepository = new ItemRepository(_dataContext);
            WarehouseTransactionRepository = new WarehousetransactionRepository(_dataContext);
        }

        public IWarehouseRepository WarehouseRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IWarehouseTransactionRepository WarehouseTransactionRepository { get; }

        public Task SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}
