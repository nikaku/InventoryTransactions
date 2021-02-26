using InventoryTransactions.Application.Commands;
using InventoryTransactions.Application.Dtos;
using InventoryTransactions.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using InventoryTransactions.Application.Commands.Item;
using InventoryTransactions.Application.Dtos.Item;
using InventoryTransactions.Application.Queries.Item;

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
        public async Task<IActionResult> GetItem([FromQuery] GetItemQuery getItemQuery)
        {
            var iteminDb = await Mediator.Send(getItemQuery);

            if (iteminDb == null)
            {
                return NotFound();
            }

            return Ok(iteminDb);
        }

        [HttpGet]
        [Route("GetItems")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItems([FromQuery]GetItemsQuery getItemsQuery)
        {
            var items = await Mediator.Send(getItemsQuery);
            return Ok(items);
        }

        [HttpPost]
        [Route("CreateItem")]
        [ProducesResponseType(typeof(GetItemDto), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> CreateItem(CreateItemCommand createItemCommand)
        {
            var res = await Mediator.Send(createItemCommand);

            return CreatedAtAction(nameof(GetItem), new { id = res.Id }, res);
        }
    }
}
