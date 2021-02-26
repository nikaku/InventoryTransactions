using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Dtos.Item;
using InventoryTransactions.Application.Interfaces;
using MediatR;

namespace InventoryTransactions.Application.Queries.Item
{
    public class GetItemQuery : IRequest<GetItemDto>
    {
        public int Id { get; set; }
    }

    public class GetItemGetItemQueryHandler : IRequestHandler<GetItemQuery, GetItemDto>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public GetItemGetItemQueryHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<GetItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var item = _itemService.GetItem(request.Id);
            var itemDto = _mapper.Map<GetItemDto>(item);
            return itemDto;
        }
    }
}
