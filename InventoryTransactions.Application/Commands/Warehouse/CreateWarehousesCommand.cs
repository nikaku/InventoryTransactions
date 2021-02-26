using AutoMapper;
using InventoryTransactions.Application.Dtos.Warehouse;
using InventoryTransactions.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryTransactions.Application.Commands.Warehouse
{
    public class CreateWarehousesCommand : IRequest<GetWarehouseDto>
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class CreateWarehousesCommandHandler : IRequestHandler<CreateWarehousesCommand, GetWarehouseDto>
    {
        private readonly IMapper _mapper;
        private readonly IWarehouseService _warehouseService;

        public CreateWarehousesCommandHandler(IMapper mapper, IWarehouseService warehouseService)
        {
            _mapper = mapper;
            _warehouseService = warehouseService;
        }
        public async Task<GetWarehouseDto> Handle(CreateWarehousesCommand request, CancellationToken cancellationToken)
        {
            var whsInDb = _warehouseService.AddWarehouse(new Domain.Entities.Warehouse.Warehouse
            {
                Location = request.Location,
                Name = request.Name
            });

            var whsDto = _mapper.Map<GetWarehouseDto>(whsInDb);
            return whsDto;
        }
    }
}
