using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryTransactions.Application.Mappings;

namespace InventoryTransactions.Application.Dtos.Warehouse
{
    public class GetWarehouseDto : IMapFrom<Domain.Entities.Warehouse.Warehouse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
