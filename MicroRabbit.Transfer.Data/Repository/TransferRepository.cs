using MicroRabbit.Transfer.Data.Context;
using MicroService.Transfer.Domain.Interfaces;
using MicroService.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDBContext _ctx;
        public TransferRepository(TransferDBContext context)
        {
            _ctx = context;
        }

        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLog.Add(transferLog);
            _ctx.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLog;
        }
    }
}
