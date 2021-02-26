using System.Net;
using System.Threading.Tasks;
using InventoryTransactions.Application.Commands.WarehouseTransactions;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTransactions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseTransactionsController : ApiControllerBase
    {
        [HttpPost]
        [Route("Reciept")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateReciept(CreateReceiptCommand createReceiptCommand)
        {
            return Ok();
        }
    }
}
