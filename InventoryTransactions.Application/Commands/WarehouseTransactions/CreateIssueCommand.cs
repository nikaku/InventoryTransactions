using InventoryTransactions.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryTransactions.Application.Commands.WarehouseTransactions
{
    public class CreateIssueCommand : IRequest
    {
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public DateTime PostingDate { get; set; }
    }

    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Unit>
    {
        private readonly IWarehouseTransactionService _warehouseTransactionService;

        public CreateIssueCommandHandler(IWarehouseTransactionService warehouseTransactionService)
        {
            _warehouseTransactionService = warehouseTransactionService;
        }
        public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            _warehouseTransactionService.Issue(request);
            return Unit.Value;
        }
    }
}
