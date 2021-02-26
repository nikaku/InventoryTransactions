using InventoryTransactions.Application.Commands.WarehouseTransactions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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
           var res = await Mediator.Send(createReceiptCommand);
           return Ok();
        }

        [HttpPost]
        [Route("Issue")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateIssue(CreateIssueCommand createIssueCommand)
        {
            var res = await Mediator.Send(createIssueCommand);
            return Ok();
        }
    }
}
