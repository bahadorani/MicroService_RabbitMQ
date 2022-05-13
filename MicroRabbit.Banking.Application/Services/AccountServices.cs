using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Model;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroService_RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Services
{
   public class AccountServices : IAccountServices
    {
        private IAccountRepository _repository;
        private IEventBus _bus;
        public AccountServices(IAccountRepository repository,IEventBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccount()
        {
           return _repository.GetAccounts();
        }

        public void Transfer(TransferAccount transferAccount)
        {
            var createTransferCommand = new CreateTransferCommand(
                transferAccount.FromAccount,
                transferAccount.ToAccount,
                transferAccount.TransferAmount
            );
            _bus.SendCommand(createTransferCommand);
        }
    }
}
