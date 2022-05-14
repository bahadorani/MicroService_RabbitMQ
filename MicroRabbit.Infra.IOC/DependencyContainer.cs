using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Infra.Bus;
using MicroService_RabbitMQ.Domain.Core.Bus;
using MicroRabbit.Banking.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Data.Repository;
using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.CommandHandler;
using MicroService.Transfer.Application.Interfaces;
using MicroService.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroService.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Events;
using MicroService.Transfer.Domain.EventHandler;

namespace MicroRabbit.Infra.IOC
{
   public  class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp=>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(),scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Command
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler > ();

            //Application Service
            services.AddTransient<IAccountServices, AccountServices>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<BankingDBContext>();
            services.AddTransient<TransferDBContext>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
           
       

        }
    }
}
