using AutoMapper;
using InventoryTransactions.Application.Mappings;
using InventoryTransactions.Domain.Entities.Item;

namespace InventoryTransactions.Application.Dtos
{
    public class GetItemDto : IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
    }
}
