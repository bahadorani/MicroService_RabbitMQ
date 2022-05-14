using MicroService.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Transfer.Domain.Interfaces
{
   public interface ITransferRepository
    {
       void Add(TransferLog transferLog);
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
