using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Core.Entities.Warehouse;

namespace InventoryTransactions.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public Warehouse GetWarehouse(int id)
        {
            return _warehouseRepository.Get(id);
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _warehouseRepository.GetAll();
        }

        public Warehouse AddGetWarehouse(Warehouse warehouse)
        {
            var res = _warehouseRepository.Add(warehouse);
            return res;
        }
    }
}
