using InventoryTransactions.Application.Mappings;

namespace InventoryTransactions.Application.Dtos.Item
{
    public class GetItemDto : IMapFrom<Domain.Entities.Item.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
    }
}
