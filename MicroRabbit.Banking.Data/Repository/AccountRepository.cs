using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDBContext _context;
        public AccountRepository(BankingDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _context.Account;
        }
    }
}
