﻿namespace InventoryTransactions.Domain.Entities.Warehouse
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Priority { get; set; }
    }
}
