using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
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
        public AccountServices(IAccountRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Account> GetAccount()
        {
           return _repository.GetAccounts();
        }
    }
}
