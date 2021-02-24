using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Core.Entities.Warehouse;

namespace InventoryTransactions.Application.Interfaces
{
    public interface IWarehouseService
    {
        Warehouse GetWarehouse(int id);
        IEnumerable<Warehouse> GetWarehouses();
        Warehouse AddGetWarehouse(Warehouse warehouse);
    }
}
