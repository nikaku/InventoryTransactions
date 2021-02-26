﻿using InventoryTransactions.Application.Commands;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace InventoryTransactions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetItem")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItem([FromQuery] GetItemQuery getItemCommand)
        {
            var iteminDb = await Mediator.Send(getItemCommand);

            if (iteminDb == null)
            {
                return NotFound();
            }

            return Ok(iteminDb);
        }

        [HttpGet]
        [Route("GetItems")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItems([FromQuery]GetItemsQuery itemsQuery)
        {
            var items = await Mediator.Send(itemsQuery);
            return Ok(items);
        }

        [HttpPost]
        [Route("CreateItem")]
        [ProducesResponseType(typeof(GetItemDto), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> CreateItem(CreateItemCommand item)
        {
            var res = await Mediator.Send(item);

            return CreatedAtAction("GetItem", new { id = res.Id }, res);
        }
    }
}
