using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InventoryTransactions.Application.Interfaces;
using MediatR;

namespace InventoryTransactions.Application.Queries.WarehouseTransactions
{
    public class GetCumulativeQuantityOnWarehouseQuery : IRequest<int>
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
    }

    public class GetCumulativeQuantityOnWarehouseQueryHandler : IRequestHandler<GetCumulativeQuantityOnWarehouseQuery, int>
    {
        private readonly IWarehouseTransactionService _warehouseTransactionService;

        public GetCumulativeQuantityOnWarehouseQueryHandler(IWarehouseTransactionService warehouseTransactionService)
        {
            _warehouseTransactionService = warehouseTransactionService;
        }

        public async Task<int> Handle(GetCumulativeQuantityOnWarehouseQuery request, CancellationToken cancellationToken)
        {
            return _warehouseTransactionService.GetCumulativeQuantityOnWarehouse(request.ItemId, request.WarehouseId);
        }
    }
}
