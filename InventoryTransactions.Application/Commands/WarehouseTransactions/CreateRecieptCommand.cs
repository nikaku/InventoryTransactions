using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace InventoryTransactions.Application.Commands.WarehouseTransactions
{
    public class CreateRecieptCommand : IRequest<bool>
    {
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public DateTime PostingDate { get; set; }
    }

    public class CreateRecieptCommandHandler : IRequestHandler<CreateRecieptCommand, bool>
    {
        public CreateRecieptCommandHandler()
        {
            
        }
        public Task<bool> Handle(CreateRecieptCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
