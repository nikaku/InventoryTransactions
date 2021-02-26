using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InventoryTransactions.Application.Commands;
using InventoryTransactions.Application.Commands.Item;
using InventoryTransactions.Application.Commands.Warehouse;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Dtos.Item;
using InventoryTransactions.Application.Queries;
using InventoryTransactions.Application.Queries.Item;
using InventoryTransactions.Application.Queries.Warehouse;

namespace InventoryTransactions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetWarehouse")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWarehouse([FromQuery] GetWarehouseQuery getWarehouseQuery)
        {
            var whsInDb = await Mediator.Send(getWarehouseQuery);

            if (whsInDb == null)
            {
                return NotFound();
            }

            return Ok(whsInDb);
        }

        [HttpGet]
        [Route("GetWarehouses")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWarehouses([FromQuery] GetWarehousesQuery getWarehousesQuery)
        {
            var items = await Mediator.Send(getWarehousesQuery);
            return Ok(items);
        }

        [HttpPost]
        [Route("CreateWarehouse")]
        [ProducesResponseType(typeof(GetItemDto), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> CreateItem(CreateWarehousesCommand createWarehousesCommand)
        {
            var res = await Mediator.Send(createWarehousesCommand);

            return CreatedAtAction(nameof(GetWarehouse), new { id = res.Id }, res);
        }
    }
}
