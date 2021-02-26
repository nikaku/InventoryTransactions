using AutoMapper;
using InventoryTransactions.Application.Dtos.Warehouse;
using InventoryTransactions.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryTransactions.Application.Queries.Warehouse
{
    public class GetWarehouseQuery : IRequest<GetWarehouseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
    public class GetWarehouseQueryHandler : IRequestHandler<GetWarehouseQuery, GetWarehouseDto>
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public GetWarehouseQueryHandler(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        public async Task<GetWarehouseDto> Handle(GetWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouse = _warehouseService.GetWarehouse(request.Id);
            var warehouseDto = _mapper.Map<GetWarehouseDto>(warehouse);
            return warehouseDto;
        }
    }
}
