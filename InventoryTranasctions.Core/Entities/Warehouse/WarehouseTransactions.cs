using System;

namespace InventoryTransactions.Core.Entities.Warehouse
{
    public class WarehouseTransactions
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int CumulativeQuantity { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PostingDate { get; set; }
    }
}
