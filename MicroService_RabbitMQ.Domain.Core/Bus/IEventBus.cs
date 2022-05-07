using MicroService_RabbitMQ.Domain.Core.Commands;
using MicroService_RabbitMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService_RabbitMQ.Domain.Core.Bus
{
   public interface IEventBus
    {
        Task SendCommand<T>(T Command) where T : Command;
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;

    }
}
