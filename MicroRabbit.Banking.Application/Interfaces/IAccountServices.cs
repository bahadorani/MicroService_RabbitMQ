using MicroRabbit.Banking.Application.Model;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Interfaces
{
   public interface IAccountServices
    {
        IEnumerable<Account> GetAccount();
        void Transfer(TransferAccount transferAccount);
    }
}
