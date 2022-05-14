﻿using MicroService.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Transfer.Application.Interfaces
{
   public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
