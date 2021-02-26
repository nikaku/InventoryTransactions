using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Application.Queries.Warehouse;
using InventoryTransactions.Core.Contracts.Interfaces;
using InventoryTransactions.Core.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Contracts.Interfaces;
using InventoryTransactions.Domain.Contracts.Interfaces.Repositories;
using InventoryTransactions.Domain.Entities.Warehouse;

namespace InventoryTransactions.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseService(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }
        public Warehouse GetWarehouse(int id)
        {
            return _warehouseRepository.Get(id);
        }

        public IEnumerable<Warehouse> GetWarehouses(GetWarehousesQuery getWarehouseQuery)
        {
            return _warehouseRepository.FindAll(x =>
                (x.Location == getWarehouseQuery.Location || getWarehouseQuery.Location == null) &&
                (x.Name == getWarehouseQuery.Name || getWarehouseQuery.Name == null) &&
                (x.Id == getWarehouseQuery.Id || getWarehouseQuery.Id == 0)
            );
        }

        public Warehouse AddWarehouse(Warehouse warehouse)
        {
            var res = _warehouseRepository.Add(warehouse);
            _unitOfWork.SaveChanges();
            return res;
        }
    }
}
