using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Dtos.Item;
using InventoryTransactions.Application.Interfaces;
using MediatR;

namespace InventoryTransactions.Application.Queries.Item
{
    public class GetItemsQuery : IRequest<IEnumerable<GetItemDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
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
            var items = _itemService.GetItems(request);
            var itemDtos = _mapper.Map<IEnumerable<GetItemDto>>(items);
            return itemDtos;
        }
    }
}
