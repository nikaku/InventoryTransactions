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
    public class GetCumulativeQuantityQuery : IRequest<int>
    {
        public int ItemId { get; set; }
    }

    public class GetCumulativeQuantityQueryHandler : IRequestHandler<GetCumulativeQuantityQuery, int>
    {
        private readonly IWarehouseTransactionService _warehouseTransactionService;

        public GetCumulativeQuantityQueryHandler(IWarehouseTransactionService warehouseTransactionService)
        {
            _warehouseTransactionService = warehouseTransactionService;
        }

        public async Task<int> Handle(GetCumulativeQuantityQuery request, CancellationToken cancellationToken)
        {
            return _warehouseTransactionService.GetCumulativeQuantity(request.ItemId);
        }
    }
}
