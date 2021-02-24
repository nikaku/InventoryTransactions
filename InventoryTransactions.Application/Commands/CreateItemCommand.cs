using AutoMapper;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Interfaces;
using InventoryTransactions.Domain.Entities.Item;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryTransactions.Application.Commands
{
    public class CreateItemCommand : IRequest<GetItemDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }

    }
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, GetItemDto>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<GetItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _itemService.AddItem(
                new Item
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    SerialNumber = request.SerialNumber
                });

            var itemDto = _mapper.Map<GetItemDto>(item);
            return itemDto;
        }
    }
}
