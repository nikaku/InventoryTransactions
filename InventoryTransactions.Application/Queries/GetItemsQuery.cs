using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Interfaces;
using MediatR;

namespace InventoryTransactions.Application.Queries
{
    public class GetItemsQuery : IRequest<IEnumerable<GetItemDto>>
    {
    }

    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<GetItemDto>>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = _itemService.GetItems();
            var itemDtos = _mapper.Map<IEnumerable<GetItemDto>>(items);
            return itemDtos;
        }
    }
}
