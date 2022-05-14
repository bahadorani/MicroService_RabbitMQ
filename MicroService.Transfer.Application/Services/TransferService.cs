using MicroService.Transfer.Application.Interfaces;
using MicroService.Transfer.Domain.Interfaces;
using MicroService.Transfer.Domain.Models;
using MicroService_RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _eventBus;
        public TransferService(ITransferRepository repository,IEventBus bus)
        {
            _transferRepository = repository;
            _eventBus = bus;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
