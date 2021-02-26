using System;

namespace InventoryTransactions.Domain.Entities.Warehouse
{
    public class WarehouseTransaction
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int ItemId { get; set; }
        public Item.Item Item { get; set; }
        public int Quantity { get; set; }
        public int CumulativeQuantity { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PostingDate { get; set; }
    }
}
