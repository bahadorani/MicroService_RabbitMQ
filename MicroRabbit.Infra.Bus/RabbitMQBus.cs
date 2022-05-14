using MediatR;
using MicroService_RabbitMQ.Domain.Core.Bus;
using MicroService_RabbitMQ.Domain.Core.Commands;
using MicroService_RabbitMQ.Domain.Core.Events;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly List<Type> _eventType;
        private readonly Dictionary<string, List<Type>> _handler;
        private readonly IServiceScopeFactory _serviceFactory;
        public RabbitMQBus(IMediator mediator,IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _eventType = new List<Type>();
            _handler = new Dictionary<string, List<Type>>();
            _serviceFactory = serviceScopeFactory;
        }
        public Task SendCommand<T>(T Command) where T : Command
        {
            return _mediator.Send(Command);
        }
        //publish events to the RabbitMQ Queses
        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection=factory.CreateConnection())
            using(var channel= connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("",eventName,null,body);
            }
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handelerType = typeof(TH);

            if(!_eventType.Contains(typeof(T)))
            {
                _eventType.Add(typeof(T));
            }

            if(!_handler.ContainsKey(eventName))
            {
                _handler.Add(eventName,new List<Type>());
            }
            if(_handler[eventName].Any(s=>s.GetType() == handelerType))
            {
                throw new ArgumentException("This HandlerType is already registerd.");
            }

            _handler[eventName].Add(handelerType);
            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var eventName = typeof(T).Name;
            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Cunsumer_Received;
            channel.BasicConsume(eventName,true,consumer);
        }

        private async Task Cunsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                await ProcessEvent(eventName,message).ConfigureAwait(false);
            }
            catch(Exception ex)
            { }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handler.ContainsKey(eventName))
            {
                using (var scope = _serviceFactory.CreateScope())
                {
                    var subscriptions = _handler[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);
                        if (handler == null) continue;
                        var eventType = _eventType.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var conreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                        await (Task)conreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
            }
        }
    }
}
