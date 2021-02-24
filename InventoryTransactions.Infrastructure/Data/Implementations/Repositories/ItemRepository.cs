using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Item;

namespace InventoryTransactions.Infrastructure.Data.Implementations.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context)
        {

        }

        private DataContext ItemContext => Context as DataContext;

    }
}
