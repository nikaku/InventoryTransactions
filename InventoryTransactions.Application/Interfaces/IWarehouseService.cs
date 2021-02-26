using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Queries.Warehouse;
using InventoryTransactions.Domain.Entities.Warehouse;

namespace InventoryTransactions.Application.Interfaces
{
    public interface IWarehouseService
    {
        Warehouse GetWarehouse(int id);
        IEnumerable<Warehouse> GetWarehouses(GetWarehousesQuery itemQuery);
        Warehouse AddWarehouse(Warehouse warehouse);
    }
}
