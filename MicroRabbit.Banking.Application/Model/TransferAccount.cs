using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Model
{
   public class TransferAccount
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public int TransferAmount { get; set; }
    }
}
