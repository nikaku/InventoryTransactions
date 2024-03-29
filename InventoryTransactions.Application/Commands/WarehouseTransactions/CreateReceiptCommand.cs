﻿using System;
using System.Threading;
using System.Threading.Tasks;
using InventoryTransactions.Application.Interfaces;
using MediatR;

namespace InventoryTransactions.Application.Commands.WarehouseTransactions
{
    public class CreateReceiptCommand : IRequest
    {
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public DateTime PostingDate { get; set; }
    }

    public class CreateRecieptCommandHandler : IRequestHandler<CreateReceiptCommand, Unit>
    {
        private readonly IWarehouseTransactionService _transactionService;

        public CreateRecieptCommandHandler(IWarehouseTransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<Unit> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            _transactionService.Receipt(request);
            return Unit.Value;
        }
    }
}
