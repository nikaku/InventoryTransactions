using System;
using InventoryTransactions.Application.Commands.WarehouseTransactions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using InventoryTransactions.Application.Queries.WarehouseTransactions;

namespace InventoryTransactions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseTransactionsController : ApiControllerBase
    {
        [HttpPost]
        [Route("Receipt")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateReceipt(CreateReceiptCommand createReceiptCommand)
        {
            try
            {
                await Mediator.Send(createReceiptCommand);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("Issue")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateIssue(CreateIssueCommand createIssueCommand)
        {
            try
            {
                await Mediator.Send(createIssueCommand);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetCumulativeQuantityQuery")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCumulativeQuantity([FromQuery]GetCumulativeQuantityQuery GetCumulativeQuantityQuery)
        {
            int quantity;
            try
            {
                quantity = await Mediator.Send(GetCumulativeQuantityQuery);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(quantity);
        }

        [HttpGet]
        [Route("GetCumulativeQuantityQueryOnWarehouse")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCumulativeQuantityQueryOnWarehouse([FromQuery] GetCumulativeQuantityOnWarehouseQuery cumulativeQuantityOnWarehouseQuery)
        {
            int quantity;
            try
            {
                quantity = await Mediator.Send(cumulativeQuantityOnWarehouseQuery);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(quantity);
        }
    }
}
