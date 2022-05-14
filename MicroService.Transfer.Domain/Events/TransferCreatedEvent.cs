using MicroService_RabbitMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.Events
{
   public class TransferCreatedEvent:Event
    {
        public int From { get;protected  set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }

        public TransferCreatedEvent(int from,int to,decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
