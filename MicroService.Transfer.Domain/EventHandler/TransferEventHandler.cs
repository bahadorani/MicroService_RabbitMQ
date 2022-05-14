using MicroRabbit.Transfer.Domain.Events;
using MicroService.Transfer.Domain.Interfaces;
using MicroService.Transfer.Domain.Models;
using MicroService_RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Transfer.Domain.EventHandler
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                 FromAccount=@event.From,
                 ToAccount=@event.To,
                 TransferAmount=@event.To
            });
            return Task.CompletedTask;
        }
    }
}
