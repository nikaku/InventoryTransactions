using InventoryTransactions.Application.Dtos.Warehouse;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InventoryTransactions.Application.Interfaces;

namespace InventoryTransactions.Application.Queries.Warehouse
{
    public class GetWarehousesQuery : IRequest<IEnumerable<GetWarehouseDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, IEnumerable<GetWarehouseDto>>
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public GetWarehousesQueryHandler(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetWarehouseDto>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehouses = _warehouseService.GetWarehouses(request);
            var whsDtos = _mapper.Map<IEnumerable<GetWarehouseDto>>(warehouses);
            return whsDtos;
        }
    }
}
